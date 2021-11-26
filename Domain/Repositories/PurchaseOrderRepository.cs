using Domain.Models;
using Intermedia_.Repositories;
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
        EntradaDeMercanciaRepository entradaMercaciaRepo = new EntradaDeMercanciaRepository();
        cbrComprasSAPEntryRepository SAPEntryRepo = new cbrComprasSAPEntryRepository();

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
            PurchaseOrderEntryModel NewEntry = new PurchaseOrderEntryModel(newEntry);

            //NewEntry.agregar()
        }


        public PurchaseOrderModel getPurchaseOrder(int docEntrey)
        {
            PurchaseOrderModel aa = new PurchaseOrderModel(docEntrey,true);
            return aa;
        }

        public List<PurchaseOrderModel> getPurchaseOrderAbiertasHeaders(string Whscode)
        {
            var ordenes = headerRepo.getAbiertas(Whscode);

            var res = new List<PurchaseOrderModel>();

            ordenes.ForEach(docEntry =>
            {
                res.Add(new PurchaseOrderModel(docEntry));
            });

            return res;
        }

        public void generarEntradaMercancia(int docEntry)
        {
            PurchaseOrderModel po = new PurchaseOrderModel(docEntry);

            EntradaDeMercancia em = new EntradaDeMercancia();

            entradaMercaciaRepo.generarEntradaDeMercancia(em);



        }





    }
}
