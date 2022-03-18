using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Proveedor
{
    public class ProveedorSAPRepository 
    {

        private MasterRepository masterRepo = MasterRepository.GetInstance();

        public List<ProveedorModelSAP> listaProveeodres()
        {

            List<ProveedorModelSAP> listaProveedores = new List<ProveedorModelSAP>();

            var proveedores = masterRepo.doQuery("select CardCode,CardName from OCRD where CardCode like '%PN%'");

            while (!proveedores.EoF)
            {
                ProveedorModelSAP proveedor = new ProveedorModelSAP();
                proveedor.Code = proveedores.Fields.Item("CardCode").Value;
                proveedor.Nombre = proveedores.Fields.Item("CardName").Value;

                listaProveedores.Add(proveedor);

                proveedores.MoveNext();
            }


            return listaProveedores;
        }

        public ProveedorModelSAP obtenerProveedorCodigo(string code)
        {

            var proveedor = masterRepo.doQuery("select CardCode,CardName from OCRD where CardCode = '" + code + "'");

            proveedor.MoveFirst();

            ProveedorModelSAP proveedorModel = new ProveedorModelSAP();
            proveedorModel.Code = proveedor.Fields.Item("CardCode").Value;
            proveedorModel.Nombre = proveedor.Fields.Item("CardName").Value;

            return proveedorModel;

        }
    }
}
