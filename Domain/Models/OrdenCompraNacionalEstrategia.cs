using SAP.Models;
using SAP.Repositories;
using SAP.Repositories.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrdenCompraNacionalEstrategia : IOrdenCompraEstrategia
    {
        private PurchaseOrderHeaderRepository headerRepository { get; set; }

        private PurchaseOrderEntryRespository entryRepository { get; set; }
        private EntradaDeMercanciaRepository entradaDeMercanciaRepository { get; set; }

        public OrdenCompraNacionalEstrategia() {
            headerRepository = new PurchaseOrderHeaderRepository();
            entryRepository = new PurchaseOrderEntryRespository();
            entradaDeMercanciaRepository = new EntradaDeMercanciaRepository();
         }

        public PurchaseOrderHeader getPurchaseOrderHeader(int docEntry)
        {
          return this.headerRepository.getOne(docEntry);
       
        }

        public List<PurchaseOrderEntry> ObtenerListaDeEntriesOrdenDeCompra(int docEntry)
        {
            return entryRepository.ObtenerListaDeEntriesOrdenDeCompra(docEntry);
        }

        public int GenerarEntradaMercancia(EntradaDeMercancia docEntry)
        {
            return entradaDeMercanciaRepository.GenerarEntradaMercancia(docEntry);

        }

    
    }
}
