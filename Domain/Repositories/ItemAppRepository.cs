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
    class ItemAppRepository
    {
        private ItemRepository ItemRepo;
        private AliasRepository AliasRepo;
        private ItemSAPRepository SAPRepo;
        public ItemAppRepository() {
            ItemRepo = new ItemRepository();
            AliasRepo = new AliasRepository();
            SAPRepo = new ItemSAPRepository();
        
        }



        //public ItemAppModel ObtenerItemPorItemCode(string ItemCode) {

        //    ItemAppModel Item = new ItemAppModel();


        //    var AliasHQItemId=0;
        //    var ItemSAP = SAPRepo.ObtenerItemPorItemCode(ItemCode);

        //    if (ItemSAP == null) {

        //        AliasHQItemId = AliasRepo.getItemId(ItemCode);
        //        ItemRepo.getByID(AliasHQItemId);
        //    }

        //    // cuando el codigo de barra es el item y en sap está registrado el alias
                
        //}


    }
}
