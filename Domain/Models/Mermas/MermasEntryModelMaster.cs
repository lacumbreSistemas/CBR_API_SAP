using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
    public class MermasEntryModelMaster
    {
        public string? codigoProducto { get; set; }
        public double cantidad { get; set; } 
        public DateTime? fecha { get; set; }
        public bool? deleted { get; set; }
        public int? deletedId { get; set; }
        public string? usuario { get; set; }
        public int numero { get; set; }

        public string NombreProducto { get; set; }
        public bool ifSAP { get; set; }
        //private

        public MermasEntryModelMaster() { 
        

        }

        public void setNombreProducto() {
            ItemSAPRepository itemSAPRepository = new ItemSAPRepository();
            var item = itemSAPRepository.ObtenerItemPorItemCode(codigoProducto);

            if (item == null)
            {

                NombreProducto = "No matriculado";
            }
            else
            {

                NombreProducto = item.ItemName;
            }


        }
    }
}
