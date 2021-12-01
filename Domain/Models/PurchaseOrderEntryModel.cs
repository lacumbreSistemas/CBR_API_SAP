using Intermedia_.Repositories;
using Intermedia_;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Models
{
    public class PurchaseOrderEntryModel
    {

        //Publics
        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public  double cantidadOrdenada { get; set; }
        public double cantidadRecibida { get; set; }
      


        //Privates
        private cbr_ComprasSAP_Escaneo_Repository intermediaEntryRepository { get; set; }
              
              
            
        //Constructores

        public PurchaseOrderEntryModel(int docEntry, string nombreProducto, string codigoProducto)
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.docEntry = docEntry;
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
            this.cantidadRecibida = this.intermediaEntryRepository.GetItemReceived(docEntry, codigoProducto);
        }

        public PurchaseOrderEntryModel()
        {

        }
        public PurchaseOrderEntryModel(PurchaseOrderEntryModel newEntry)
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.docEntry = docEntry;
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
            this.cantidadRecibida = this.intermediaEntryRepository.GetItemReceived(docEntry, codigoProducto);
        }

     

    }
}
