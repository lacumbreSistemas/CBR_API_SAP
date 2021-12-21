using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public interface IOrdenCompraEstrategia
    {
        PurchaseOrderHeader getPurchaseOrderHeader(int docEntry);

        List<PurchaseOrderEntry> ObtenerListaDeEntriesOrdenDeCompra(int docEntry);

        int GenerarEntradaMercancia(EntradaDeMercancia docEntry);

    }
}
