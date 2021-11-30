using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbrComprasSAPEntryRepository:MasterRespository
    {
      
        public double GetItemReceived(int docEntry, string itemCode) 
        {
           var cantidad = db.cbr_ComprasSAP_Entry.Where(i => i.ItemCode == itemCode && i.BaseEntry == docEntry).Sum(i => i.Quantity);

            if(cantidad != null)
            {
                return (double) cantidad;
            } else
            {
                return 0;
            }
        }


        public List<cbr_ComprasSAP_Entry> GetItemReceivedDetail(int docEntry, string itemCode) {


            return null;
        }


        public void Post(cbr_ComprasSAP_Entry Entry) {

            db.cbr_ComprasSAP_Entry.Add(Entry);
            db.SaveChanges();
            
        }
    }
}
