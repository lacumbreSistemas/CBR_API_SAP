﻿using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
    public class PurchaseOrderEntryRespository: MasterRepository
    {
        public PurchaseOrderEntryRespository() { }
        public List<PurchaseOrderEntry> getPurchaseOrderEntries(int docEntry)
        {
            doQuery(@"select            E.ItemCode as codigoProducto,
                                        i.ItemName as nombreProducto,
                                        E.Quantity as cantidadOrdenada,
                                        E.DocEntry as docEntry
                                        FROM POR1 E
                                        inner join OITM i on i.ItemCode = E.ItemCode
                                        where  E.DocEntry =" + docEntry);

            List<PurchaseOrderEntry> poe = new List<PurchaseOrderEntry>();

            for (int i = 0; i < recordSet.RecordCount; i++)
            {
                PurchaseOrderEntry newPurchaseOrderEntry = new PurchaseOrderEntry(recordSet.Fields.Item("docEntry").Value, recordSet.Fields.Item("nombreProducto").Value, recordSet.Fields.Item("codigoProducto").Value, recordSet.Fields.Item("cantidadOrdenada").Value);
                poe.Add(newPurchaseOrderEntry);
                recordSet.MoveNext();
            }
         
            return poe;


        }

    }
}
