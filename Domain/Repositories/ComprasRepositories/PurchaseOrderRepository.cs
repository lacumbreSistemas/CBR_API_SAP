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
        OrdenCompraNacionalEstrategia estrategia = new OrdenCompraNacionalEstrategia();

        
       
        public PurchaseOrderModel getPurchaseOrder(int numeroDeOrdenDeCompra, bool includeEntries =false)
        {
            PurchaseOrderModel aa = new PurchaseOrderModel(numeroDeOrdenDeCompra, estrategia, includeEntries);
            return aa;
        }

        public List<PurchaseOrderModel> getPurchaseOrderAbiertasHeaders(string WhsCode)
        {
            var ordenes = headerRepo.getAbiertas(WhsCode);

            var res = new List<PurchaseOrderModel>();
            res = mapearOCs(ordenes);
            return res;
        }


        //private


     private List<PurchaseOrderModel> mapearOCs(List<PurchaseOrderHeader> OCsSAP) {
                    var OCs = new List<PurchaseOrderModel>();
                    OCsSAP.ForEach(OC =>
                    {
                        PurchaseOrderModel oc = new PurchaseOrderModel();

                        oc.docEntry = OC.docEntry;
                        oc.numeroOrdenDeCompra = OC.docNum;
                        oc.codigoProveedor = OC.cardCode;
                        oc.nombreProveedor = OC.cardName;
                        oc.fechaCreacion = OC.docDueDate;
                        oc.fechaEntrega = OC.taxDate;
                        

                        OCs.Add(oc);
                    });

                    return OCs;

                }

        public int guardarEntradaMercancia(int docEntry) {

            var PO = getPurchaseOrder(docEntry,false);

            return   PO.GenerarEntradaMercancia(); 
        }



    }
}
