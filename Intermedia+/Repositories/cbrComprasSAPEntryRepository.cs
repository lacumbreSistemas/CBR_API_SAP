using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbrComprasSAPEntryRepository
    {
        Data db = new Data();
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
    }
}
