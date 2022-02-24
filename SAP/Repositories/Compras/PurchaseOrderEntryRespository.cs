using SAP.Contracts;
using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SAP.Repositories
{
    public class PurchaseOrderEntryRespository: IOCEntryRepo
    {

        MasterRepository masterRepo = MasterRepository.GetInstance();


        //private MasterRepository _masterRespository;
        public PurchaseOrderEntryRespository() {

        //_masterRespository = MasterRepository.Instance;
        }
    
        public List<PurchaseOrderEntry> ObtenerListaDeEntriesOrdenDeCompra(int? docEntry)
        {
         var recordSet =  masterRepo.doQuery(@"select                      E.ItemCode as codigoProducto,
                                                i.ItemName as nombreProducto,
                                                E.Quantity as cantidadOrdenada,
                                                E.DocEntry as docEntry,
                                                E.Baseline as Baseline,
                                              E.OcrCode  as NormaReparto
                                        FROM POR1 E
                                        inner join OITM i on i.ItemCode = E.ItemCode
                                        where  E.DocEntry =" + docEntry);

            List<PurchaseOrderEntry> poe = new List<PurchaseOrderEntry>();

            for (int i = 0; i < recordSet.RecordCount; i++)
            {
                
                PurchaseOrderEntry newPurchaseOrderEntry = new PurchaseOrderEntry(

                                        recordSet.Fields.Item("docEntry").Value,
                                        recordSet.Fields.Item("nombreProducto").Value,
                                        recordSet.Fields.Item("codigoProducto").Value,
                                        recordSet.Fields.Item("cantidadOrdenada").Value,
                                        recordSet.Fields.Item("Baseline").Value,
                                        recordSet.Fields.Item("NormaReparto").Value

                                        );


                poe.Add(newPurchaseOrderEntry);
                recordSet.MoveNext();
            }
         
            return poe;


        }

        public PurchaseOrderEntry ObtenerEntrieDeOrdenDeCompra(int? docEntry, string itemCode) {

            var recordSet = masterRepo.doQuery(@"select                E.ItemCode as codigoProducto,
                                            i.ItemName as nombreProducto,
                                            E.Quantity as cantidadOrdenada,
                                            E.DocEntry as docEntry,
                                            E.Baseline as Baseline,
                                            E.OcrCode  as NormaReparto
                                        FROM POR1 E
                                        inner join OITM i on i.ItemCode = E.ItemCode
                                        where  E.DocEntry = " + docEntry+"and E.itemCode = '"+itemCode+"'");


            return new PurchaseOrderEntry(

                                        recordSet.Fields.Item("docEntry").Value,
                                        recordSet.Fields.Item("nombreProducto").Value,
                                        recordSet.Fields.Item("codigoProducto").Value,
                                        recordSet.Fields.Item("cantidadOrdenada").Value,
                                        recordSet.Fields.Item("Baseline").Value,
                                        recordSet.Fields.Item("NormaReparto").Value


                                        );

        }


        public double ObtenerCantidadOrdenada(int? docEntry, string itemCode) {

            var recordSet = masterRepo.doQuery("select quantity from Por1 where docentry = "+docEntry+" and itemCode = '"+itemCode+"'");

            double cantidadOrdenada = recordSet.Fields.Item("Quantity").Value;

            if (cantidadOrdenada == 0 || cantidadOrdenada == null)
                throw new Exception("Item no existe en orden de compra");

            return cantidadOrdenada;
        }


        public int obtenerLineNum(int? docEntry, string itemCode) {
            //Conectar();
            var recordSet = masterRepo.doQuery("select LineNum from Por1 where docentry = " + docEntry + " and itemCode = '" + itemCode + "'");
            return recordSet.Fields.Item("LineNum").Value;
        }

    }
}
