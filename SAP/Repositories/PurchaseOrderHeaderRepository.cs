using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
    public class PurchaseOrderHeaderRepository : MasterRepository
    {

        public PurchaseOrderHeaderRepository() { }

        public PurchaseOrderHeader getOne(int docEntry)
        {
            doQuery(@"Select oc.DocEntry,TaxDate,DocNum,oc.CardCode,DocDueDate,p.CardName from OPOR oc

                            inner join OCRD P on oc.CardCode = p.CardCode

                            where oc.Docentry = " + docEntry);

            PurchaseOrderHeader newPurchaseOrderHeader = new PurchaseOrderHeader(); 

            for (int i = 0; i < recordSet.RecordCount; i++)
            {
                newPurchaseOrderHeader.docEntry = recordSet.Fields.Item("DocEntry").Value;
                newPurchaseOrderHeader.taxDate = recordSet.Fields.Item("TaxDate").Value;
                newPurchaseOrderHeader.docNum = recordSet.Fields.Item("DocNum").Value;
                newPurchaseOrderHeader.cardCode = recordSet.Fields.Item("CardCode").Value;
                newPurchaseOrderHeader.docDueDate = recordSet.Fields.Item("DocDueDate").Value;
                newPurchaseOrderHeader.cardName = recordSet.Fields.Item("CardCode").Value;
                recordSet.MoveNext();
            }

            return newPurchaseOrderHeader;
        }


        public List<int> getAbiertas()
        {
            //doQuery(@"Select oc.DocEntry,TaxDate,DocNum,oc.CardCode,DocDueDate,p.CardName from OPOR oc

            //                inner join OCRD P on oc.CardCode = p.CardCode

            //                where oc.Docentry = 300");

            //List<PurchaseOrderHeader> poe = new List<PurchaseOrderHeader>();

            //for (int i = 0; i < recordSet.RecordCount; i++)
            //{
            //    PurchaseOrderEntry newPurchaseOrderEntry = new PurchaseOrderHeader(recordSet.Fields.Item("docEntry").Value, recordSet.Fields.Item("nombreProducto").Value, recordSet.Fields.Item("codigoProducto").Value, recordSet.Fields.Item("cantidadOrdenada").Value);
            //    poe.Add(newPurchaseOrderEntry);
            //    recordSet.MoveNext();
            //}

            //return poe;

            var res = new List<int>();
            res.Add(300);
            res.Add(301);
            res.Add(302);
            return res;
        }





    }
}
