
using Microsoft.Win32.SafeHandles;
using SAP.Models.ComprasInternacionalesEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.ComprasInternacionales
{
    public class FacturaReservaHeaderRepository: MasterRepository
    {

        public FacturasReservaHeaderEntity getOne(int docEntry)
        {
            doQuery(@"Select oc.DocEntry,TaxDate,DocNum,oc.CardCode,DocDueDate,p.CardName from OPOR oc

                            inner join OCRD P on oc.CardCode = p.CardCode

                            where oc.Docentry = " + docEntry);

            FacturasReservaHeaderEntity newPurchaseOrderHeader = new FacturasReservaHeaderEntity();

           
            //}

            while (!recordSet.EoF)
            {
                //newPurchaseOrderHeader.docEntry = recordSet.Fields.Item("DocEntry").Value;
                //newPurchaseOrderHeader.taxDate = recordSet.Fields.Item("TaxDate").Value;
                //newPurchaseOrderHeader.docNum = recordSet.Fields.Item("DocNum").Value;
                //newPurchaseOrderHeader.cardCode = recordSet.Fields.Item("CardCode").Value;
                //newPurchaseOrderHeader.docDueDate = recordSet.Fields.Item("DocDueDate").Value;
                //newPurchaseOrderHeader.cardName = recordSet.Fields.Item("CardCode").Value;

                

                recordSet.MoveNext();
            }

            return newPurchaseOrderHeader;
        }


        public List<FacturasReservaHeaderEntity> getAbiertas(string WhsCode) {

            doQuery(@"select T0.DocEntry,
                            T0.TaxDate,
                            T0.DocNum,
                            T0.CardCode,
                            T0.DocDueDate,
                            p.CardName 
                      from OPCH T0
                           inner join PCH1 T1 ON T0.DocEntry = T1.DocEntry
                           inner join OCRD P on t0.CardCode = P.CardCode
                           left join PDN1 T2 ON T1.DocEntry = T2.BaseEntry and T1.LineNum = T2.BaseLine
                           left join OPDN T3 ON T2.DocEntry = T3.DocEntry
                       where T0.DocStatus = 'O' and t0.InvntSttus = 'O' and T0.isIns = 'Y' and(T3.DocStatus is null or t3.CANCELED = 'Y') and t1.WhsCode = '"+WhsCode+ @"'
                           and T0.DocType = 'I'
                       group by  T0.DocEntry, T0.TaxDate, T0.DocNum, T0.CardCode, T0.DocDueDate, p.CardName
                       order by t0.DocNum desc");

            List<FacturasReservaHeaderEntity> FRAbiertas = new List<FacturasReservaHeaderEntity>();

            while (!recordSet.EoF) {
                FacturasReservaHeaderEntity FR = new FacturasReservaHeaderEntity();

                FR.docEntry = recordSet.Fields.Item("DocEntry").Value;
                FR.docNum = recordSet.Fields.Item("DocNum").Value;
                FR.cardCode = recordSet.Fields.Item("CardCode").Value;
                FR.taxDate = recordSet.Fields.Item("TaxDate").Value;
                FR.cardName = recordSet.Fields.Item("CardName").Value;
                FR.docDueDate = recordSet.Fields.Item("docDueDate").Value;

                FRAbiertas.Add(FR);
            }


            return FRAbiertas;


        }
    }
}
