using SAP.Models;
using SAP.Repositories.Compras;
using SAP.Repositories.ComprasInternacionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrdenCompraImportadoEstrategia : IOrdenCompraEstrategia
    {
        private EntradaDeMercanciaRepository entradaDeMercanciaRepository { get; set; }
        private FacturaReservaHeaderRepository headerRepository { get; set; }
         private FacturaReservaEntryRepository entriesRepository { get; set; }
       public  OrdenCompraImportadoEstrategia()
        {
            this.headerRepository = new FacturaReservaHeaderRepository();
            entriesRepository = new FacturaReservaEntryRepository();
            entradaDeMercanciaRepository = new EntradaDeMercanciaRepository();
        }

        public PurchaseOrderHeader getPurchaseOrderHeader(int docEntry)
        {
            var header =  headerRepository.getOne(docEntry);

            PurchaseOrderHeader newHeader = new PurchaseOrderHeader();

            newHeader.cardCode = header.cardCode;
            newHeader.cardName =  header.cardName;
            newHeader.docDueDate = header.docDueDate;
            newHeader.docEntry = header.docEntry;
            newHeader.docNum = header.docNum;

            return newHeader;

        }

        public List<PurchaseOrderEntry> ObtenerListaDeEntriesOrdenDeCompra(int docEntry)
        {
           var entriesFR = entriesRepository.ObtenerListaDeEntriesFacturaReserva(docEntry);

            List<PurchaseOrderEntry> entries = new List<PurchaseOrderEntry>();

            entriesFR.ForEach(i=> {

                PurchaseOrderEntry entrie = new PurchaseOrderEntry(i.docEntry, i.nombreProducto, i.codigoProducto, i.cantidadOrdenada, i.baseLine, i.normaReparto);

                entries.Add(entrie);

            });


            return entries;
        }

        public int GenerarEntradaMercancia(EntradaDeMercancia docEntry)
        {
           return entradaDeMercanciaRepository.GenerarEntradaMercanciaImportados(docEntry);


        }
    }
}
