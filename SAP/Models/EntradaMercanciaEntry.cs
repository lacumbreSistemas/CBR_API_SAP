using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
    class EntradaMercanciaEntry
    {

        int id;

        ItemSAP item { get; set; }

        double quantityOrdened { get; set; }
    }
}
