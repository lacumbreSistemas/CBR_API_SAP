using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Models;
using SAP.Repositories;
using SAP.Repositories.Compras;
using SAP.Repositories.ComprasInternacionales;

namespace Domain.Models.ComprasInternacionalesModels
{
    public class FacturaReservaModel
    {

        //public
        public int docEntry { get; set; }
        public DateTime fechaCreacion { get; set; }

        public int docNum { get; set; }
        public string codigoProveedor { get; set; }

        public DateTime fechaEntrega { get; set; }
        public string nombreProveedor { get; set; }
        public List<FacturaReservaEntryModel> entries { get; set; }


        //private 

        private List<EscaneoConsultaModel> Escaneos { get; set; }
        private FacturaReservaEntryRepository entriesRepository { get; set; }
        private FacturaReservaHeaderRepository headerRepository { get; set; }
        private EntradaDeMercanciaRepository entradaDeMercanciaRepository { get; set; }
        private cbr_ComprasSAP_Escaneo_Repository escaneosIntermedia;



        public FacturaReservaModel(int docEntry, bool includeEntries = false, bool includeEscaneos = false) {

            this.entries = new List<FacturaReservaEntryModel>();
            this.entriesRepository = new FacturaReservaEntryRepository();
            this.headerRepository = new FacturaReservaHeaderRepository();


            getFacuraRerserva(docEntry, includeEntries);
          
         
            entradaDeMercanciaRepository = new EntradaDeMercanciaRepository();

            if (includeEscaneos)
            {
                Escaneos = new List<EscaneoConsultaModel>();
                escaneosIntermedia = new cbr_ComprasSAP_Escaneo_Repository();
                getEscaneos();
            }
        

        }

        public FacturaReservaModel() {
            
        }

        public void getEscaneos() {

            var escaneos = escaneosIntermedia.ObtenerEscaneosPorDocEntry(this.docEntry);

            escaneos.ForEach(i => {

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


        public void getFacuraRerserva(int docEntry, bool includeEntries) {

            var header = headerRepository.getOne(docEntry);

            this.docEntry = header.docEntry;
            this.docNum = header.docNum;
            this.codigoProveedor = header.cardCode;
            this.fechaCreacion = header.docDueDate;
            this.fechaEntrega = header.taxDate;
            this.nombreProveedor = header.cardName;

            if (includeEntries) {
                var entriesSAP = entriesRepository.ObtenerListaDeEntriesFacturaReserva(this.docEntry);

                entriesSAP.ForEach(entry =>
                {
                    FacturaReservaEntryModel entrie = new FacturaReservaEntryModel();
                    entrie.docEntry = entry.docEntry;
                    entrie.codigoProducto = entry.codigoProducto;
                    entrie.nombreProducto = entry.nombreProducto;
                    entrie.cantidadOrdenada = entry.cantidadOrdenada;
                    entries.Add(entrie);

                });


            }


        }



        private EntradaDeMercancia mapearEM()
        {

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



        public int GenerarEntradaMercancia()
        {



            int DocEntryEM = entradaDeMercanciaRepository.GenerarEntradaMercanciaImportados(mapearEM());

            Escaneos.ForEach(escaneo =>
            {
                escaneo.establercerEntradaMercancia(DocEntryEM);
            });


            return DocEntryEM;

        }




    }
}
