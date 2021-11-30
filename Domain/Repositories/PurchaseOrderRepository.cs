﻿using Domain.Models;
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
            res = mápearOCs(ordenes);
            ////var p = new List<int>();

            //ordenes.ForEach(OCs =>
            //{


            //    PurchaseOrderModel Poe = new PurchaseOrderModel();

            //    Poe.docEntry = OCs.docEntry;
            //    Poe.docNum = OCs.docNum;
            //    Poe.codigoProveedor = OCs.cardCode;
            //    Poe.nombreProveedor = OCs.cardName;
            //    Poe.fechaCreacion = OCs.docDueDate;
            //    Poe.fechaEntrega = OCs.taxDate;



            //    res.Add(Poe);
            //});

            return res;
        }



        private List<PurchaseOrderModel> mápearOCs(List<PurchaseOrderHeader> OCsSAP) {
            var OCs = new List<PurchaseOrderModel>();
            OCsSAP.ForEach(OC =>
            {


                PurchaseOrderModel oc = new PurchaseOrderModel();

                oc.docEntry = OC.docEntry;
                oc.docNum = OC.docNum;
                oc.codigoProveedor = OC.cardCode;
                oc.nombreProveedor = OC.cardName;
                oc.fechaCreacion = OC.docDueDate;
                oc.fechaEntrega = OC.taxDate;



                OCs.Add(oc);
            });

            return OCs;

        }



    }
}
