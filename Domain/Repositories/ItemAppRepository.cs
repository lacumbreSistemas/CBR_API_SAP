using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using HQ.Repositories;
using SAP.Repositories;


namespace Domain.Repositories
{
   public class ItemAppRepository
    {
     
        public ItemAppRepository() {
            
        
        }


        public ItemAppModel obtenerItem(string ItemCode) {

            ItemAppModel item = new ItemAppModel();

            item.findByItemloockupcode(ItemCode);

            return item;
        
        }


    }
}
