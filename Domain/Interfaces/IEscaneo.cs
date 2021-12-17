using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface IEscaneo
    {
        public int numeroOrdenDeCompra { get; set; }
        public int usuario { get; set; }
        public double cantidad { get; set; }

        public DateTime fecha { get; set; }
        public int numeroEntradaDeMercancía { get; set; }

    }
}
