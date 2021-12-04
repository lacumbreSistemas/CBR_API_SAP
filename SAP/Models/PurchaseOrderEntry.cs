using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
   public class PurchaseOrderEntry
    {
         public int docEntry { get; set; }
        public string nombreProducto { get; set; }

        public string codigoProducto { get; set; }
        public double cantidadOrdenada { get; set; }
        public int baseLine { get; set; }
        public string normaReparto { get; set; }

        
        public PurchaseOrderEntry(int docEntry, string nombreProducto, string codigoProducto, double cantidadOrdenada, int baseLine, string normaReparto)
        {
            this.docEntry = docEntry;
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
            this.cantidadOrdenada = cantidadOrdenada;
            this.baseLine = baseLine;
            this.normaReparto = normaReparto;

        }

    }
}
