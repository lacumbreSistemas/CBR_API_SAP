using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SAP.Repositories
{
    public class PurchaseOrderEntryRespository
    {

        private MasterRepository _masterRespository;
        public PurchaseOrderEntryRespository() {

        _masterRespository = MasterRepository.Instance;
        }
    
        public List<PurchaseOrderEntry> getPurchaseOrderEntries(int docEntry)
        {
            MasterRepository.Instance.doQuery(@"select            E.ItemCode as codigoProducto,
                                        i.ItemName as nombreProducto,
                                        E.Quantity as cantidadOrdenada,
                                        E.DocEntry as docEntry
                                        FROM POR1 E
                                        inner join OITM i on i.ItemCode = E.ItemCode
                                        where  E.DocEntry =" + docEntry);

            List<PurchaseOrderEntry> poe = new List<PurchaseOrderEntry>();

            for (int i = 0; i < _masterRespository.recordSet.RecordCount; i++)
            {
                PurchaseOrderEntry newPurchaseOrderEntry = new PurchaseOrderEntry (_masterRespository.recordSet.Fields.Item("docEntry").Value, _masterRespository.recordSet.Fields.Item("nombreProducto").Value, _masterRespository.recordSet.Fields.Item("codigoProducto").Value, _masterRespository.recordSet.Fields.Item("cantidadOrdenada").Value);
                poe.Add(newPurchaseOrderEntry);
                _masterRespository.recordSet.MoveNext();
            }
         
            return poe;


        }

    }
}
