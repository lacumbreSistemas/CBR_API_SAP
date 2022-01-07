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
        public bool matriculado { get; set; }

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
                    this.descripcion = "N/A";
                    this.matriculado = false;
                    this.itemloockupcode = itemloockupcode;
                }
                else
                {
                    var item = itemRepository.getByID(itemid);
                    this.itemId = item.ID;
                    this.itemloockupcode = item.ItemLookupCode;
                    this.descripcion = item.Description;
                    this.matriculado = true;
                }


            }
            else {

                this.itemId = itemid;
                this.itemloockupcode = itemsap.ItemCode;
                this.descripcion = itemsap.ItemName;
                this.matriculado = true;
            }

            
        }
    }
}
