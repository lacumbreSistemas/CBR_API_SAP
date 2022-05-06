using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories.Produccion
{
    public class ProduccionEntryRepo:MasterRespository
    {
        public cbr_ProduccionEntry crearCbr_SolicitudDevolucionEntry(cbr_ProduccionEntry Entry)
        {

            db.cbr_ProduccionEntry.Add(Entry);
            db.SaveChanges();

            return Entry;
        }


        public List<cbr_ProduccionEntry> obtenerEntriesPornumber(int numero)
        {

            return db.cbr_ProduccionEntry.Where(i => i.numero == numero).ToList();

        }


        public List<cbr_ProduccionEntry> obtenerEntriesPorNumberItemCode(int numero, string itemCode)
        {

            return db.cbr_ProduccionEntry.Where(i => i.numero == numero && i.itemcode == itemCode && !i.cancelado).ToList();

        }

    }
}
