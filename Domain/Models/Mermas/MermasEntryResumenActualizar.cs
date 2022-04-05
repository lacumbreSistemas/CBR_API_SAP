using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
    public class MermasEntryResumenActualizar:MermaEntryResumenMaster
    {
        public MermasEntryResumenActualizar(string itemCode, int numero) {

            this.numero = numero;
            this.codigoProducto = itemCode; 
        }

    }
}
