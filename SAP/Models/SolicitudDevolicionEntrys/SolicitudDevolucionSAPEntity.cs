using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.SolicitudDevolicionEntrys
{
   public class SolicitudDevolucionSAPEntity
    {
        public int DocEntry { get; set; }

        public string CardCode { get; set; }
        public string WhsCode { get; set; }

        public string Comentario { get; set; }

        public int codigoPersonaCompras { get; set; }

        public string EncargadoDevolucion { get; set; }
        public DateTime Fecha { get; set; }

        public List<SolicitudDevolucionEntrySAPEntity> solicitudDevolucionEntrySAPEntities { get; set; }

        public SolicitudDevolucionSAPEntity() {
            solicitudDevolucionEntrySAPEntities = new List<SolicitudDevolucionEntrySAPEntity>();
        }


    }
}
