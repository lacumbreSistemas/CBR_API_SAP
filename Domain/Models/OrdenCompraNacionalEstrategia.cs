using SAP.Models;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    class OrdenCompraNacionalEstrategia : IOrdenCompraEstrategia
    {
        private PurchaseOrderHeaderRepository headerRepository { get; set; }

        OrdenCompraNacionalEstrategia() {
            headerRepository = new PurchaseOrderHeaderRepository();
         }

        public PurchaseOrderHeader getPurchaseOrderHeader(int docEntry)
        {
          return this.headerRepository.getOne(docEntry);
       
        }
    }
}
