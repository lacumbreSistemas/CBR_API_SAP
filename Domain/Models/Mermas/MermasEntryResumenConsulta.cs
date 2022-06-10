using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
   public class MermasEntryResumenConsulta: MermaEntryResumenMaster
    {

        private ItemSAPRepository itemSAPRepo { get; set;  }


        public MermasEntryResumenConsulta(string itemCode) {

            codigoProducto = itemCode;

            itemSAPRepo = new ItemSAPRepository();
            setNombreProducto();


        }

        public MermasEntryResumenConsulta() { }

        private void setNombreProducto() {

            var item = itemSAPRepo.ObtenerItemPorItemCode(codigoProducto);

            if (item == null)
            {

                descripcionProducto = "No matriculado";

            }
            else {
                descripcionProducto = item.ItemName; 
            }
        }

    }
}
