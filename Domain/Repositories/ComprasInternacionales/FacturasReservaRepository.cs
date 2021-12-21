using Domain.Models;

using SAP.Models.ComprasInternacionalesEntitys;
using SAP.Repositories.ComprasInternacionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.ComprasInternacionales
{
    public class FacturasReservaRepository
    {
        FacturaReservaHeaderRepository headerRepo = new FacturaReservaHeaderRepository();
        OrdenCompraImportadoEstrategia estrategia = new OrdenCompraImportadoEstrategia();

        public PurchaseOrderModel getFacturaReserva(int numeroDeOrdenDeCompra, bool includeEntries = false, bool includeEscaneos = false)
        {
            PurchaseOrderModel aa = new PurchaseOrderModel(numeroDeOrdenDeCompra,estrategia, includeEntries, includeEscaneos);
            return aa;
        }


        public List<PurchaseOrderModel> getPurchaseOrderAbiertasHeaders(string WhsCode)
        {
            var ordenes = headerRepo.getAbiertas(WhsCode);

            var res = new List<PurchaseOrderModel>();
            res = mapearOCs(ordenes);
            return res;
        }


        private List<PurchaseOrderModel> mapearOCs(List<FacturasReservaHeaderEntity> OCsSAP)
        {
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

        public int guardarEntradaMercancia(int docEntry)
        {

            //var PO = getPurchaseOrder(docEntry, false, true);
            //PO.GenerarEntradaMercancia();
            //return PO.GenerarEntradaMercancia();

            var FR = getFacturaReserva(docEntry, false, true);


            return FR.GenerarEntradaMercancia();

        }

    }
}
