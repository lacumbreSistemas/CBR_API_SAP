using SAP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Produccion
{
    public class ListaMaterialProduccionRepoSAP : IListaMaterialesSAP
    {

        public ListaMaterialProduccionRepoSAP() { }
     

        MasterRepository _MasterRepository = MasterRepository.GetInstance();
        IListaMaterialesSAP estrategia;
        public List<ListaMaterialEntity> obtenerListasMateriales() {

            

            return estrategia.obtenerListasMateriales();

        }

        public ListaMaterialProduccionRepoSAP(IListaMaterialesSAP estrategia) {


            this.estrategia = estrategia;


        }
        public List<ListaMaterialesDetalleEntity> obtenerListaMaterialesDetalle(string code) {

            var recetas = _MasterRepository.doQuery(@"select detalle.Code,detalle.ItemName from oitt cabecera inner join 
                                                        ITT1 detalle on detalle.Father = cabecera.Code

                                                        where cabecera.code ='" + code + "'");
            List<ListaMaterialesDetalleEntity> detalleReceta = new List<ListaMaterialesDetalleEntity>();

            while (!recetas.EoF) {
                ListaMaterialesDetalleEntity listaMaterialesDetalleEntity = new ListaMaterialesDetalleEntity();

                listaMaterialesDetalleEntity.Code = recetas.Fields.Item("code").Value;
                listaMaterialesDetalleEntity.Name = recetas.Fields.Item("ItemName").Value;

                detalleReceta.Add(listaMaterialesDetalleEntity);

                recetas.MoveNext();

            }

            return detalleReceta;
        }


        public ListaMaterialEntity obtenerListaMaterialCabecera(string code) {
            var listaMaterialConsulta = _MasterRepository.doQuery("select Name,Code,Qauntity from oitt where code = '"+code+"'");
           ListaMaterialEntity listasMaterial = new ListaMaterialEntity();
            listaMaterialConsulta.MoveFirst();
          
            listasMaterial.Name = listaMaterialConsulta.Fields.Item("Name").Value;
            listasMaterial.Code = listaMaterialConsulta.Fields.Item("Code").Value;
            listasMaterial.Quantity = listaMaterialConsulta.Fields.Item("Qauntity").Value;



            return listasMaterial;
        }

    }
}
