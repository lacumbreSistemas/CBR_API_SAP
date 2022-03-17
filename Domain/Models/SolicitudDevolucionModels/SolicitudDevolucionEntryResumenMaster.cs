using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryResumenMaster
    {

        public int Numero { get; set; }
        public string CodigoProducto { get; set; }
        public double? CantidadEscaneada { get; set; }

        public string DescripcionProducto { get; set; }
    }
}
