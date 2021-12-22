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

        public string descripciónProducto { get; set; }
        public string usuario { get; set; }
        public double cantidad { get; set; }

        public DateTime fecha { get; set; }
        public int baseLine { get; set; }
        
        //private
        private ItemAppModel item { get; set; }


        public EscaneoMasterModel() {

            item = new ItemAppModel();

            item.findByItemloockupcode(codigoProducto);

            this.descripciónProducto = item.descripcion;

        }
      
    }
}
