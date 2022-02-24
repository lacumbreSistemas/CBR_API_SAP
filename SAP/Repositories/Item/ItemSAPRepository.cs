using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
   public class ItemSAPRepository
    {
        MasterRepository masterRepo = MasterRepository.GetInstance();
        public ItemSAP ObtenerItemPorItemCode(string ItemCode) {



            var recordSet = masterRepo.doQuery("select ItemCode, ItemName from Oitm where itemCode = '"+ ItemCode+"'");
            ItemSAP Item = new ItemSAP();
           
            
            while (!recordSet.EoF) {

                Item.ItemCode = recordSet.Fields.Item("ItemCode").Value;
                Item.ItemName = recordSet.Fields.Item("ItemName").Value;

                recordSet.MoveNext(); 
            }

            return recordSet.RecordCount == 0? null : Item ;
        }
    }
}
