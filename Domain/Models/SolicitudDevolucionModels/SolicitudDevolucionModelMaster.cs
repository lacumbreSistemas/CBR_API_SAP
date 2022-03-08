using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
   public class SolicitudDevolucionModelMaster
    {

        public int Numero { get; set; }
        
        public string TiendaCode { get; set; }
        public string ProveedorCode { get; set; }
        public DateTime? Fecha { get; set; }

        public string Comentario { get; set; }

        public bool? Anulado { get; set; }
    }
}
