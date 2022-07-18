using HQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
   public class ProcesosEntryResumenSAP: ProcesosEntryResumenMaster
    {

        public decimal precioVenta { get; set; }
        public decimal ventaTotal { get; set; }

        
        public void establecerPrecioVenta() {
            ItemRepository itemRepository = new ItemRepository();
            var item = itemRepository.getByItemLoockupCode(codigoProducto);

            precioVenta = item.Price;
            ventaTotal = (decimal)cantidadEscaneada * precioVenta;
        }
        public ProcesosEntryResumenSAP() {
         
         
        }
    }
}
