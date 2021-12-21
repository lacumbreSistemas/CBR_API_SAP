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

        public int docNum { get; set; }
        public string codigoProveedor { get; set; }

        public DateTime fechaEntrega { get; set; }
        public string nombreProveedor { get; set; }

       

        public List<PurchaseOrderEntryModel> entries { get; set; }

        // private

        private PurchaseOrderEntryRespository entriesRepository { get; set; }
        private IOrdenCompraEstrategia _estrategia { get; set; }

        private cbr_ComprasSAP_Escaneo_Repository escaneosIntermedia;
         
        private EntradaDeMercanciaRepository entradaDeMercanciaRepository { get; set; }

      
        private List<EscaneoConsultaModel> Escaneos { get; set; }



        public PurchaseOrderModel(int docEntry, IOrdenCompraEstrategia estrategia, bool includeEntries = false,bool includeEscaneos = false)
        {
            this.entriesRepository = new PurchaseOrderEntryRespository();
            this.entries = new List<PurchaseOrderEntryModel>();
            _estrategia = estrategia;


                getPurchaseOrderHeader(docEntry, includeEntries);
               
                entradaDeMercanciaRepository = new EntradaDeMercanciaRepository();

            if (includeEscaneos)
            {
                Escaneos = new List<EscaneoConsultaModel>();
                escaneosIntermedia = new cbr_ComprasSAP_Escaneo_Repository();
                getPurchaseOrderEscaneos();
            }
        }

        public PurchaseOrderModel()
        {

        }

        public void getPurchaseOrderEscaneos()
        {
            var escaneos = escaneosIntermedia.ObtenerEscaneosPorDocEntry(this.docEntry);

            escaneos.ForEach(i=> {

                EscaneoConsultaModel _Escaneo = new EscaneoConsultaModel();

                _Escaneo.baseLine = i.baseLine;
                _Escaneo.cantidad = i.cantidad;
                _Escaneo.codigoProducto = i.itemCode;
                _Escaneo.fecha = i.fecha;
                _Escaneo.numeroEntradaDeMercancía = i.entradaMercanciaDocEntry;
                _Escaneo.numeroOrdenDeCompra = i.baseEntry;
                Escaneos.Add(_Escaneo);
                

            });

        }

        public void getPurchaseOrderHeader(int docEntry, bool includeEntries)
        {
            var header = _estrategia.getPurchaseOrderHeader(docEntry);
            this.docEntry = header.docEntry;
            this.fechaCreacion = header.docDueDate;
            this.docNum = header.docNum;
            this.codigoProveedor = header.cardCode;
            this.fechaEntrega = header.taxDate;
            this.nombreProveedor = header.cardName;



            if (includeEntries)
            {
                var entriesSAP = _estrategia.ObtenerListaDeEntriesOrdenDeCompra(docEntry);

                entriesSAP.ForEach(entry =>
                {
                    PurchaseOrderEntryModel Entry = new PurchaseOrderEntryModel();
                    Entry.docEntry = entry.docEntry;
                    Entry.codigoProducto = entry.codigoProducto;
                    Entry.nombreProducto = entry.nombreProducto;
                    Entry.cantidadOrdenada = entry.cantidadOrdenada;
                   
                    this.entries.Add(Entry);
                });
            }



        }

        public void withEscaneos() {
          


        }
        #region 
        //private List<EscaneoConsultaModel> ObtenerEscaneos()
        //{

        //    //var escaneos = escaneosIntermedia.ObtenerEscaneosPorDocEntry(this.docEntry).GroupBy(i => new { i.baseEntry, i.itemCode }).ToList();
        //    //var escaneos = Escaneos.GroupBy(i => new { i.baseEntry, i.itemCode }).ToList();

        //    //Escaneos.ForEach(i => {

        //    //    EscaneoConsultaModel _escaneo = new EscaneoConsultaModel();

        //    //    _escaneo.cantidad = Convert.ToDouble(i.Sum(i => i.cantidad));
        //    //    _escaneo.codigoProducto = i.FirstOrDefault().itemCode.ToString();
        //    //    //_escaneo.numeroEntradaDeMercancía = null; 
        //    //    _escaneo.numeroOrdenDeCompra = Convert.ToInt32(i.FirstOrDefault().baseEntry.ToString());
        //    //    _escaneo.fecha = DateTime.Now;
        //    //    _escaneo.usuario = Convert.ToInt32(i.FirstOrDefault().userID.ToString());
        //    //    _escaneo.baseLine = Convert.ToInt32(i.FirstOrDefault().baseLine.ToString());

        //    //    Escaneos.Add(_escaneo);

        //    //});

        //    //return Escaneos;


        //}
        #endregion



        private EntradaDeMercancia mapearEM() {

            //var escaneos = ObtenerEscaneos();


            EntradaDeMercancia EM = new EntradaDeMercancia();
            EM.CardCode = this.codigoProveedor;


            Escaneos.GroupBy(i => new { i.numeroOrdenDeCompra, i.codigoProducto }).ToList().ForEach(i =>
            {

                EntradaMercanciaEntry EME = new EntradaMercanciaEntry();
                EME.BaseEntry = Convert.ToInt32(i.FirstOrDefault().numeroOrdenDeCompra.ToString());
                EME.BaseLine = Convert.ToInt32(i.FirstOrDefault().baseLine.ToString());
                EME.ItemCode = i.FirstOrDefault().codigoProducto.ToString();
                EME.Quantity = Convert.ToDouble(i.Sum(i => i.cantidad));


                EM.Entries.Add(EME);
            });



            return EM;



        }


        public int GenerarEntradaMercancia(){

          int entradaMercanciaDocEntry =   _estrategia.GenerarEntradaMercancia(mapearEM());

            Escaneos.ForEach(escaneo =>
            {
                escaneo.entradaMercanciaDocEntry = entradaMercanciaDocEntry;
                escaneo.establercerEntradaMercancia(entradaMercanciaDocEntry);
            });


            return entradaMercanciaDocEntry;

        }
    }   
}
