using HQ.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Repositories
{
    public class ItemRepository : MasterRepository ,  IItemRepository  
    {
        public Item getByID(int id)
        {
            return data.Item.Find(id);
        }

        public Item getByItemLoockupCode(string itemLoockupCode)
        {
            return data.Item.FirstOrDefault(i=> i.ItemLookupCode == itemLoockupCode);
        }

    
    }
}
