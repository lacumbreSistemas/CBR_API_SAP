using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryModelMaster
    {
        public string? CodigoProducto { get; set; }
        public double? cantidad { get; set; }
        public DateTime? fecha { get; set; }
        public bool? deleted { get; set; }
        public int? deletedId { get; set; }
        public string? usuario { get; set; }
        public int numero { get; set; }

        public string NombreProducto { get; set; }
        //private
        private ItemSAPRepository _itemSAPRepo { get; set; }

        public SolicitudDevolucionEntryModelMaster() {

            _itemSAPRepo = new ItemSAPRepository();
            
        }


        public void setNombreProducto()
        {

            var item = _itemSAPRepo.ObtenerItemPorItemCode(CodigoProducto);

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
