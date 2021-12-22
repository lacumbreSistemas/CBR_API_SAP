using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQ.Contracts;
using HQ.Repositories;
using SAP.Repositories;

namespace Domain.Models
{
    public class ItemAppModel
    {
        public int itemId { get; set; }
        public string itemloockupcode { get; set; }
        public string descripcion { get; set; }

        private IAliasRepository aliasRepository { get; set; }

        private IItemRepository itemRepository { get; set; }

        private ItemSAPRepository itemSAP { get; set; }

        public ItemAppModel()
        {
            itemSAP = new ItemSAPRepository();
            this.aliasRepository = new AliasRepository();
            this.itemRepository = new ItemRepository();
            
        }

        public void findByItemloockupcode(string itemloockupcode)
        {

            var itemsap = itemSAP.ObtenerItemPorItemCode(itemloockupcode);
            int itemid = aliasRepository.getItemId(itemloockupcode);

            if (itemsap == null)
            {


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
            else {

                this.itemId = itemid;
                this.itemloockupcode = itemsap.ItemCode;
                this.descripcion = itemsap.ItemName;
            
            }

            
        }
    }
}
