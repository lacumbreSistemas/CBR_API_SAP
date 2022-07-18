using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
   public class ProcesosEntryResumenMaster
    {
        public int numero { get; set; }
        public string codigoProducto { get; set; }
        public double cantidadEscaneada { get; set; }

        public string descripcionProducto { get; set; }
    }
}
