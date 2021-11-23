using HQ.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Repositories
{
    public class AliasRepository : MasterRepository, IAliasRepository
    {
        public int getItemId(string itemLookupCode)
        {
            var itemID = data.Alias.FirstOrDefault(i => i.Alias1 == itemLookupCode);
            return itemID != null ? itemID.ItemID : 0; 
        }
    }
}
