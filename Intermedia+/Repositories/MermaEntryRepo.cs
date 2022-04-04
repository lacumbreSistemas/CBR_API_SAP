using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
  public  class MermaEntryRepo:MasterRespository
    {
        public cbr_MermasEntry crearEntryDocumentoIntermedioMerma(cbr_MermasEntry entryMerma)
        {

            db.cbr_MermasEntry.Add(entryMerma);
            db.SaveChanges();

            return entryMerma; 

        }

        public List<cbr_MermasEntry> obtenerEntriesPorNumber(int number) {

            return db.cbr_MermasEntry.Where(i => i.number == number).ToList();
        
        }


        //public List<cbr_MermasEntry> obtenerItemsPorNumberItemCode(int number, string itemCode) { 
        
        //    //return db.
        
        //}
    }
}
