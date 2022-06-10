using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
   public class SolicitudDevolucionModelMaster
    {

        public int numero { get; set; }
        
        public string codigoTienda { get; set; }
        public string codigoProveedor { get; set; }
      
        public DateTime? fechaCreacion { get; set; }

        public string comentario { get; set; }

        public bool? anulado { get; set; }

        public string usuario { get; set;}
    }
}
