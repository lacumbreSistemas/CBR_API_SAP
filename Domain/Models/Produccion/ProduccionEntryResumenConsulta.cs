
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
   public class ProduccionEntryResumenConsulta: ProduccionEntryResumenConsultaMaster
    {

   
        public ProduccionEntryResumenConsulta(string itemCode) {

            codigoProducto = itemCode;
            setNombreProducto();
        }


        private void setNombreProducto()
        {
            ItemSAPRepository _itemSAPRepo = new ItemSAPRepository();
            var item = _itemSAPRepo.ObtenerItemPorItemCode(codigoProducto);

            if (item == null)
            {

                descripcionProducto = "No matriculado";
            }
            else
            {

                descripcionProducto = item.ItemName;
            }


        }

    }
}
