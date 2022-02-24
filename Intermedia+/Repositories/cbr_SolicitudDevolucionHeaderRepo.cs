using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
   public class cbr_SolicitudDevolucionHeaderRepo:MasterRespository
    {
        public cbr_SolicitudDevolucionHeader obtenerSolicitudIntermediaNumber(string number) {
            return db.cbr_SolicitudDevolucionHeader.FirstOrDefault(i=> i.number == number);
          }


        public cbr_SolicitudDevolucionHeader crearCbr_SolicitudDevolucionHeader(cbr_SolicitudDevolucionHeader solicitudDevolucionHeader)
        {


            solicitudDevolucionHeader.fecha = DateTime.Now;

            if (solicitu) { 
            
            }

                return solicitudDevolucionHeader;
        }



    }
}
