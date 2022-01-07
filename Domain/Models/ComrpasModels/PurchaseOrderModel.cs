using SAP.Models;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Repositories.Compras;
using Intermedia_;

namespace Domain.Models
{
    public class PurchaseOrderModel
    {

        // public
        public int docEntry { get; set; }
        public DateTime fechaCreacion { get; set; }

        public int numeroOrdenDeCompra { get; set; }
        public string codigoProveedor { get; set; }

        public DateTime fechaEntrega { get; set; }
        public string nombreProveedor { get; set; }

       
       

        public List<PurchaseOrderEntryModel> entries { get; set; }

        // private

     
        private IOrdenCompraEstrategia _estrategia { get; set; }

        private cbr_ComprasSAP_Escaneo_Repository escaneosIntermedia;
         
   

     


        public PurchaseOrderModel(int docEntry, IOrdenCompraEstrategia estrategia, bool includeEntries = false)
        {
          
            this.entries = new List<PurchaseOrderEntryModel>();
            escaneosIntermedia = new cbr_ComprasSAP_Escaneo_Repository();
            
            _estrategia = estrategia;
            getPurchaseOrderHeader(docEntry, includeEntries);
        }

        public PurchaseOrderModel()
        {

        }


        public List<EscaneoConsultaModel> getEscaneosSinEntradaDeMercancia()
        {
            List<EscaneoConsultaModel> escaneosConsulta = new List<EscaneoConsultaModel>();
           
            var escaneos = escaneosIntermedia.ObtenerEscaneosPorDocEntrySinIngresarSAP (this.docEntry);

            escaneos.ForEach(i=> {
                EscaneoConsultaModel _Escaneo = new EscaneoConsultaModel();
                _Escaneo.baseLine = i.baseLine;
                _Escaneo.cantidad = i.cantidad;
                _Escaneo.codigoProducto = i.itemCode;
                _Escaneo.fecha = i.fecha;
                _Escaneo.entradaMercanciaDocEntry = i.entradaMercanciaDocEntry;
                _Escaneo.ordenCompraDocEntry = i.baseEntry;
                _Escaneo.id = i.id;
                escaneosConsulta.Add(_Escaneo);
            });

            return escaneosConsulta;
        }

        public void getPurchaseOrderHeader(int docEntry, bool includeEntries)
        {
            var header = _estrategia.getPurchaseOrderHeader(docEntry);
            this.docEntry = header.docEntry;
            this.fechaCreacion = header.docDueDate;
            this.numeroOrdenDeCompra = header.docNum;
            this.codigoProveedor = header.cardCode;
            this.fechaEntrega = header.taxDate;
            this.nombreProveedor = header.cardName;



            if (includeEntries)
            {
                var entriesSAP = _estrategia.ObtenerListaDeEntriesOrdenDeCompra(docEntry);

                entriesSAP.ForEach(entry =>
                {
                    PurchaseOrderEntryModel Entry = new PurchaseOrderEntryModel(entry.docEntry,entry.codigoProducto);
                    //Entry.docEntry = entry.docEntry;
                    Entry.codigoProducto = entry.codigoProducto;
                    Entry.nombreProducto = entry.nombreProducto;
                    Entry.cantidadOrdenada = entry.cantidadOrdenada;
                   
                    this.entries.Add(Entry);
                });
            }



        }
        public int GenerarEntradaMercancia(){

            var escaneos = getEscaneosSinEntradaDeMercancia();
           

            EntradaDeMercancia EM = new EntradaDeMercancia();
            EM.CardCode = this.codigoProveedor;


            escaneos.GroupBy(i => new { i.ordenCompraDocEntry, i.codigoProducto }).ToList().ForEach(i =>
            {
                var itemcode = i.FirstOrDefault().codigoProducto.ToString();
               

                EntradaMercanciaEntry EME = new EntradaMercanciaEntry();
                EME.BaseEntry = Convert.ToInt32(i.FirstOrDefault().ordenCompraDocEntry.ToString());
                EME.BaseLine = Convert.ToInt32(i.Min(e=>e.baseLine).ToString());
                EME.ItemCode = i.FirstOrDefault().codigoProducto.ToString();
                EME.Quantity = Convert.ToDouble(i.Sum(i => i.cantidad));

                if (i.FirstOrDefault().matriculado == false)
                {
                    throw new Exception("Item " + itemcode + " No matriculado");
                }


                if (EME.Quantity > 0)
                {
                    EM.Entries.Add(EME);
                }
            });

            if (EM.Entries.Count() <= 0)
            {
                throw new Exception("No hay escaneos para generar una nueva entrada de mercancia");
            }

            int entradaMercanciaDocEntry =   _estrategia.GenerarEntradaMercancia(EM);

            escaneos.ForEach(escaneo =>
            {
                escaneo.entradaMercanciaDocEntry = entradaMercanciaDocEntry;
                escaneo.establercerEntradaMercancia();
            });


            return entradaMercanciaDocEntry;

        }
    }   
}
