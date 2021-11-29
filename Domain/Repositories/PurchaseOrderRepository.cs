using Domain.Models;
using SAP.Models;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class PurchaseOrderRepository
    {
        PurchaseOrderHeaderRepository headerRepo = new PurchaseOrderHeaderRepository();

        //public List<PurchaseOrderEntryModel> getPurchaseOrderEntries(int docEntry)
        //{

        //    //var entries = repository.getPurchaseOrderEntries(docEntry);
        //    //List<PurchaseOrderEntryModel> res = new List<PurchaseOrderEntryModel>();

        //    //entries.ForEach(item =>
        //    //{
        //    //    res.Add(new PurchaseOrderEntryModel(item.docEntry, item.nombreProducto, item.codigoProducto, item.cantidadOrdenada));
        //    //});

        //    //return res;
        //}

        public void addNewEntry(PurchaseOrderEntryModel newEntry) 
        {
            //PurchaseOrderEntryModel aa = new PurchaseOrderEntryModel(newEntry);

            //aa.agregar();
        }


        public PurchaseOrderModel getPurchaseOrder(int docEntrey)
        {
            PurchaseOrderModel aa = new PurchaseOrderModel(docEntrey,true);
            return aa;
        }

        public List<PurchaseOrderModel> getPurchaseOrderAbiertasHeaders(string WhsCode)
        {
            var ordenes = headerRepo.getAbiertas(WhsCode);

            var res = new List<PurchaseOrderModel>();

            ordenes.ForEach(docEntry =>
            {

                //PurchaseOrderModel Poe = new PurchaseOrderModel(docEntry);
                res.Add(new PurchaseOrderModel(docEntry));
            });

            return res;
        }





    }
}
