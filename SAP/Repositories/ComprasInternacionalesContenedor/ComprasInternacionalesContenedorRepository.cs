using SAP.Models.ComprasInternacionalesEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.ComprasInternacionalesContenedor
{
   public  class ComprasInternacionalesContenedorRepository :MasterRepository
    {

        MasterRepository masterRepo = MasterRepository.GetInstance();

        public List<string> obtenerContenedorAbierto(string WhsCode)
        {
            List<string> contenedores = new List<string>();

            var recordSet = masterRepo.doQuery(@" select 
                         t0.Comments
                      from OPCH T0
                            inner join PCH1 T1 ON T0.DocEntry = T1.DocEntry
                  
						   inner join por1 t4 on t4.TrgetEntry = t1.DocEntry
						   inner join OPOR t5 on t5.DocEntry = t4.DocEntry AND T5.SERIES = 79
                       where T0.DocStatus = 'O' and t0.InvntSttus = 'O' and T0.isIns = 'Y'  and t1.WhsCode = '" + WhsCode + @"'
                           and T0.DocType = 'I'
                       group by  t0.Comments
                       order by  t0.Comments desc");

            while (!recordSet.EoF)
            {

                contenedores.Add(recordSet.Fields.Item("Comments").Value);
                recordSet.MoveNext();
            }

            return contenedores;
        }


       public   List<FacturasReservaHeaderEntity> obtenerOrdenesCompraPorNumeroContenedor(string numeroContenedor) {
            List<FacturasReservaHeaderEntity> FacturasReserva = new List<FacturasReservaHeaderEntity>();

            var recordSet = masterRepo.doQuery(@" select T0.DocEntry,
                            T0.TaxDate,
                            T0.DocNum,
                            T0.CardCode,
                            T0.DocDueDate,
                            T0.CardName 
                          from OPCH T0 where Comments = '" + numeroContenedor+ "' and T0.DocStatus = 'O' and t0.InvntSttus = 'O'");

            while (!recordSet.EoF)
            {
                FacturasReservaHeaderEntity FR = new FacturasReservaHeaderEntity();

                FR.docEntry = recordSet.Fields.Item("DocEntry").Value;
                FR.docNum = recordSet.Fields.Item("DocNum").Value;
                FR.cardCode = recordSet.Fields.Item("CardCode").Value;
                FR.taxDate = recordSet.Fields.Item("TaxDate").Value;
                FR.cardName = recordSet.Fields.Item("CardName").Value;
                FR.docDueDate = recordSet.Fields.Item("docDueDate").Value;

                FacturasReserva.Add(FR);
                recordSet.MoveNext();
            }


            return FacturasReserva;
        }


        public int obtenerNumeroOrdenDecompraPorArtículo(string itemCode, string numeroContenedor) {

            var recordSet = masterRepo.doQuery(@"select c.DocEntry from PCH1 d (nolock)
                                                    inner join OPCH c on c.DocEntry = d.DocEntry
                                                    where d.ItemCode = '"+itemCode+ "' and c.Comments = '"+numeroContenedor+"'");



            return recordSet.Fields.Item("DocEntry").Value;

        }


    }
}
