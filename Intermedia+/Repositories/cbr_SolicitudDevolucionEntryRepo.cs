using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbr_SolicitudDevolucionEntryRepo: MasterRespository 
    {

        public cbr_SolicitudDevolucionEntry crearCbr_SolicitudDevolucionEntry(cbr_SolicitudDevolucionEntry Entry)
        {

            db.cbr_SolicitudDevolucionEntry.Add(Entry);
            db.SaveChanges();

            return Entry; 
        }

        public List<cbr_SolicitudDevolucionEntry> obtenerEntriesPornumber(int number) {

            return db.cbr_SolicitudDevolucionEntry.Where(i => i.number == number).ToList(); 
            
        }

        public cbr_SolicitudDevolucionEntry obtenerEntriesPorID(int id)
        {
            return db.cbr_SolicitudDevolucionEntry.FirstOrDefault(i => i.id == id);
        }

    }
}
