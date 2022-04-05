using SAP.Repositories.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
   public class MermaModelConsulta: MermasModelMaster
    {
      public int docEntry { get; set;  }

     public string nombreProveedor { get; set; } 

      public List<MermasEntryResumenConsulta> entries { get; set; }

        public void setNombreProveedor() {

            ProveedorSAPRepository proveedorSAPRepository = new ProveedorSAPRepository();
            var proveedor = proveedorSAPRepository.obtenerProveedorCodigo(codigoProveedor);
        }
        

    }
}
