using Domain.Models.Proveedor;
using SAP.Repositories.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ProveedorRepository
    {
        ProveedorSAPRepository _ProveedorSAPRepository { get; set; }


        public ProveedorRepository() {
            _ProveedorSAPRepository = new ProveedorSAPRepository();
        }

        public List<ProveedorModel> listaProveedores()
        {
            List<ProveedorModel> proveedores = new List<ProveedorModel>();

            _ProveedorSAPRepository.listaProveeodres().ForEach(i=> {

                ProveedorModel proveedor = new ProveedorModel();
                proveedor.Code = i.Code;
                proveedor.Nombre = i.Nombre;

                proveedores.Add(proveedor);

            }); 

            return proveedores; 
        }

    }
}
