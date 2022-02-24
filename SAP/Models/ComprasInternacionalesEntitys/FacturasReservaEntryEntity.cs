using SAP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.ComprasInternacionalesEntitys
{
    public class FacturasReservaEntryEntity : IOCEntry
    {

        public int docEntry { get; set; }
        public string nombreProducto { get; set; }

        public string codigoProducto { get; set; }
        public double cantidadOrdenada { get; set; }
        public int baseLine { get; set; }
        public string normaReparto { get; set; }

        public FacturasReservaEntryEntity()
        {


        }
    }
}
