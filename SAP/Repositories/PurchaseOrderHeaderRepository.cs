﻿using SAP.Models;
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


        public List<int> getAbiertas(string WhsCode)
        {

            #region 
            doQuery(@"select  T0.DocEntry,
                             
                     from OPOR T0 
                             inner join POR1 T1 ON T0.DocEntry = T1.DocEntry 
                             inner join OCRD P on t0.CardCode = P.CardCode
                             left join PDN1 T2 ON T1.DocEntry= T2.BaseEntry and T1.LineNum=T2.BaseLine 
                             left join OPDN T3 ON T2.DocEntry = T3.DocEntry
                     where T0.DocStatus = 'O' and (T3.DocStatus is null or t3.CANCELED = 'Y') and t1.WhsCode =" + WhsCode + @"
                                 and T0.DocType = 'I'
				     group by  T0.DocEntry,T0.CardCode,T0.DocDueDate,T0.TaxDate,T0.DocNum,T0.CardCode,T1.WhsCode,P.CardName");



            List<int> poe = new List<int>();


            while (!recordSet.EoF)
            {

                poe.Add(recordSet.Fields.Item("DocEntry").Value);
            }

            return poe;

            #endregion






        }
    }
}
