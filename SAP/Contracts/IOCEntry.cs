using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Contracts
{
    interface IOCEntry
    {
         int docEntry { get; set; }
         string nombreProducto { get; set; }

         string codigoProducto { get; set; }
         double cantidadOrdenada { get; set; }
         int baseLine { get; set; }
         string normaReparto { get; set; }
    }
}
