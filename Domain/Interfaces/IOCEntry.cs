using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface IOCEntry
    {

        //public
        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public double cantidadOrdenada { get; set; }
        public double cantidadEscneada { get; set; }


        //pivate 
   
    }
}
