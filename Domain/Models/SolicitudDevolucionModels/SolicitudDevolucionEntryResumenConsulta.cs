using Intermedia_;
using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryResumenConsulta: SolicitudDevolucionEntryResumenMaster
    {
        
        // prublic
     


        //private
        private ItemSAPRepository _itemSAPRepo { get; set; }

      

        public SolicitudDevolucionEntryResumenConsulta(string itemCode) {
            CodigoProducto = itemCode;
            
            _itemSAPRepo = new ItemSAPRepository();
            setNombreProducto();

        }





     


        private void setNombreProducto()
        {

            var item = _itemSAPRepo.ObtenerItemPorItemCode(CodigoProducto);

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
