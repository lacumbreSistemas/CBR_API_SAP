using Domain.Interfaces;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComprasInternacionalesModels
{
    public class FacturaReservaEntryModel : IOCEntry
    {

        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public double cantidadOrdenada { get; set; }
        public double cantidadEscneada { get; set; }


        //private 

        private cbr_ComprasSAP_Escaneo_Repository intermediaEntryRepository { get; set; }

        public FacturaReservaEntryModel() {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.cantidadEscneada = this.intermediaEntryRepository.obtenerCantidadRecibida(docEntry, codigoProducto);

        }
             

        public FacturaReservaEntryModel(FacturaReservaEntryModel newEntry) {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.docEntry = newEntry.docEntry;
            this.nombreProducto = newEntry.nombreProducto;
            this.codigoProducto = newEntry.codigoProducto;
            this.cantidadOrdenada = newEntry.cantidadOrdenada;
            this.cantidadEscneada = this.intermediaEntryRepository.obtenerCantidadRecibida(docEntry, codigoProducto);
           
        }



        //public string numeroDocumento {get; set;}

        //public
    }
}
