using SAP.Models;
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

        private FacturaReservaHeaderRepository headerRepository { get; set; }

        OrdenCompraImportadoEstrategia()
        {
            this.headerRepository = new FacturaReservaHeaderRepository();
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
    }
}
