using Intermedia_.Repositories;
using Intermedia_;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Models
{
    public class PurchaseOrderEntryModel: IOCEntry
    {

        //Publics
        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public  double cantidadOrdenada { get; set; }
        public double cantidadEscaneada { get; set; }
      


        //Privates
        private cbr_ComprasSAP_Escaneo_Repository intermediaEntryRepository { get; set; }

        //private PurchaseOrderEntryRespository entriesRepository { get; set; }

        //Constructores

        public PurchaseOrderEntryModel(int docEntry, string nombreProducto)
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.docEntry = docEntry;
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
        
            this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadRecibida(docEntry, codigoProducto);
        }

        public PurchaseOrderEntryModel()
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadRecibida(docEntry, codigoProducto);
        }
        public PurchaseOrderEntryModel(PurchaseOrderEntryModel newEntry)
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.docEntry = newEntry.docEntry;
            this.nombreProducto = newEntry.nombreProducto;
            this.codigoProducto = newEntry.codigoProducto;
            this.cantidadOrdenada = newEntry.cantidadOrdenada;
            this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadRecibida(docEntry, codigoProducto);
        }

     
            
    }
}
