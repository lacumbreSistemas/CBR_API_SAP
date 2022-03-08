using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryResumen
    {
        
        // prublic
        public string ItemCode { get; set; }
        public double? CantidadEscaneada { get; set; }

        public string DescripcionProducto { get; set; }


        //private
        private ItemSAPRepository _itemSAPRepo { get; set; }


        public SolicitudDevolucionEntryResumen(string itemCode) {
            ItemCode = itemCode; 
            _itemSAPRepo = new ItemSAPRepository();

            setNombreProducto();

        }

    






        private void setNombreProducto()
        {

            var item = _itemSAPRepo.ObtenerItemPorItemCode(ItemCode);

            if (item == null)
            {

                DescripcionProducto = "No matriculado";
            }
            else
            {

                DescripcionProducto = item.ItemName;
            }


        }

    }
}
