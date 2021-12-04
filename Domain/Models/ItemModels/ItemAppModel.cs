using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQ.Contracts;
using HQ.Repositories;
namespace Domain.Models
{
    class ItemAppModel
    {
        public int itemId { get; set; }
        public  string itemloockupcode { get; set; }
        public string descripcion { get; set; }

        private IAliasRepository aliasRepository;

        private IItemRepository itemRepository;

       public ItemAppModel()
        {
            this.aliasRepository = new AliasRepository();
            this.itemRepository = new ItemRepository();
        }

        public void findByItemloockupcode(string itemloockupcode)
        {
            int itemid = aliasRepository.getItemId(itemloockupcode);

            if (itemId == 0)
            {
                var item = itemRepository.getByItemLoockupCode(itemloockupcode);
                this.itemId = item.ID;
                this.itemloockupcode = item.ItemLookupCode;
                this.descripcion = item.Description;
            }
            else
            {
                var item = itemRepository.getByID(itemid);
                this.itemId = item.ID;
                this.itemloockupcode = item.ItemLookupCode;
                this.descripcion = item.Description;
            }
        }
    }
}
