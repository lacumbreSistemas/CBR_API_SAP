using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Proveedor
{
    public class ProveedorSAPRepository:MasterRepository
    {

        private MasterRepository masterRepo = MasterRepository.GetInstance();

        public List<ProveedorModelSAP> listaProveeodres() {

            List<ProveedorModelSAP> listaProveedores = new List<ProveedorModelSAP>();

           var proveedores = masterRepo.doQuery("select CardCode,CardName from OCRD where CardCode like '%PN%'");

            while (!proveedores.EoF) {
                ProveedorModelSAP proveedor = new ProveedorModelSAP();
                proveedor.Code = proveedores.Fields.Item("CardCode").Value;
                proveedor.Nombre = proveedores.Fields.Item("CardName").Value;

                listaProveedores.Add(proveedor);

                proveedores.MoveNext();
            }
            

            return listaProveedores;
        } 
    }
}
