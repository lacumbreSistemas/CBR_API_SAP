using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
  public  class ProduccionEntryModelMaster
    {
        public string codigoProducto { get; set; }
        public double cantidad { get; set; }

        public DateTime? fecha { get; set; }
    
        public bool? deleted { get; set; }
        public int? deletedId { get; set; }
        public string? usuario { get; set; }

        public int numero { get; set; }


        public string descripcionProducto { get; set; }


        public void setNombreProducto()
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
