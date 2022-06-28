using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EscaneoMasterModel
    {
        public int ordenCompraDocEntry { get; set; }
        public string codigoProducto { get; set; }

        public string nombreProducto { get; set; }
        public string usuario { get; set; }

        public double cantidad { get; set; }

        public DateTime fecha { get; set; }
        public int baseLine { get; set; }

       
        //private
        private ItemAppModel item { get; set; }


        public void setNombreProducto()
        {

            item = new ItemAppModel();

            item.findByItemloockupcode(codigoProducto);

            this.nombreProducto = item.descripcion;
        }

       
      
    }
}
