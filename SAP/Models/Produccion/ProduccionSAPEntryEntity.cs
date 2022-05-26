using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.Produccion
{
    public class ProduccionSAPEntryEntity
    {
        public string ItemCode { get; set; }
        public double Cantidad { get; set; }

        public decimal costoLibra { get; set; }

    }
}
