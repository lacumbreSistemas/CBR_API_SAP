using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbr_SolicitudDevolucionHeaderRepo : MasterRespository
    {
        public cbr_SolicitudDevolucionHeader obtenerSolicitudIntermediaNumber(int number) {
            return db.cbr_SolicitudDevolucionHeader.FirstOrDefault(i => i.number == number);
        }


        public int crearCbr_SolicitudDevolucionHeader(cbr_SolicitudDevolucionHeader solicitudDevolucionHeader)
        {


            solicitudDevolucionHeader.fecha = DateTime.Now;

            if (!db.cbr_SolicitudDevolucionHeader.Any())
            {
                solicitudDevolucionHeader.number = 1;
            }
            else {
                solicitudDevolucionHeader.number = db.cbr_SolicitudDevolucionHeader.Max(i => i.number) + 1;
            }

            solicitudDevolucionHeader.docEntry = 0;

            db.cbr_SolicitudDevolucionHeader.Add(solicitudDevolucionHeader);
            db.SaveChanges();



            return solicitudDevolucionHeader.number;
        }

        public List<cbr_SolicitudDevolucionHeader> obtenerSolicitudesDevolucionSinDocEntry(string WhsCode) {
            List<cbr_SolicitudDevolucionHeader> _solicitudesDevolucionSinDocEntry = new List<cbr_SolicitudDevolucionHeader>();

            _solicitudesDevolucionSinDocEntry = db.cbr_SolicitudDevolucionHeader.Where(i => i.docEntry == 0 && i.whsCode == WhsCode && i.anulado == false).ToList();

            return _solicitudesDevolucionSinDocEntry;
        }


       
     

    }
}
