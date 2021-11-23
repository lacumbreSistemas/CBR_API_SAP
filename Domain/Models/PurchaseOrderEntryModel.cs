using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
    public class PurchaseOrderEntryModel
    {
        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public  double cantidadOrdenada { get; set; }
        public double cantidadResibida { get; set; }

        private cbrComprasSAPEntryRepository intermediaRepository { get; set; }


        public PurchaseOrderEntryModel(int docEntry, string nombreProducto, string codigoProducto, double cantidadOrdenada)
        {
            intermediaRepository = new cbrComprasSAPEntryRepository();
            this.docEntry = docEntry;
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
            this.cantidadOrdenada = cantidadOrdenada;
            this.cantidadResibida = this.intermediaRepository.GetItemReceived(docEntry, codigoProducto);
        }


        public PurchaseOrderEntryModel(PurchaseOrderEntryModel newEntry)
        {
            this.docEntry = newEntry.docEntry;
            this.nombreProducto = newEntry.nombreProducto;
            this.codigoProducto = newEntry.codigoProducto;
            this.cantidadOrdenada = newEntry.cantidadOrdenada;
            this.cantidadResibida = 0;
        }

        public void agregar()
        {
            
        }
     

    }
}
