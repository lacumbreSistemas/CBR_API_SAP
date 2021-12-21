using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EscaneoMasterModel
    {
        public int numeroOrdenDeCompra { get; set; }
        public string codigoProducto { get; set; }

        public string usuario { get; set; }
        public double cantidad { get; set; }

        public DateTime fecha { get; set; }
        public int baseLine { get; set; }
        public int numeroEntradaDeMercancía { get; set; }
    }
}
