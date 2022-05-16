using SAP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Produccion
{
    public class ListaMaterialRepoSAP
    {

        MasterRepository _MasterRepository = MasterRepository.GetInstance();
        public List<ListaMaterialEntity> obtenerListasMateriales() {

            var recetas = _MasterRepository.doQuery("select code,Name from oitt");
            List<ListaMaterialEntity> listasMateriales = new List<ListaMaterialEntity>();

            while (!recetas.EoF) {
                ListaMaterialEntity listaMaterialEntity = new ListaMaterialEntity();
                listaMaterialEntity.Code = recetas.Fields.Item("code").Value;
                listaMaterialEntity.Name = recetas.Fields.Item("Name").Value;

                listasMateriales.Add(listaMaterialEntity);

                recetas.MoveNext();
            }

            return listasMateriales;

        }

        public List<ListaMaterialesDetalleEntity> obtenerListaMaterialesDetalle(string code) {

            var recetas = _MasterRepository.doQuery(@"select cabecera.Code,cabecera.Name from oitt cabecera inner join 
                                                        ITT1 detalle on detalle.Father = cabecera.Code

                                                        where cabecera.code ='" + code + "'");
            List<ListaMaterialesDetalleEntity> detalleReceta = new List<ListaMaterialesDetalleEntity>();

            while (!recetas.EoF) {
                ListaMaterialesDetalleEntity listaMaterialesDetalleEntity = new ListaMaterialesDetalleEntity();

                listaMaterialesDetalleEntity.Code = recetas.Fields.Item("code").Value;
                listaMaterialesDetalleEntity.Name = recetas.Fields.Item("Name").Value;

                detalleReceta.Add(listaMaterialesDetalleEntity);

                recetas.MoveNext();

            }

            return detalleReceta;
        }


        public ListaMaterialEntity obtenerListaMaterialCabecera(string code) {
            var listaMaterialConsulta = _MasterRepository.doQuery("select Name from oitt where code = '"+code+"'");
           ListaMaterialEntity listasMaterial = new ListaMaterialEntity();

            listaMaterialConsulta.MoveFirst();


          
            listasMaterial.Name = listaMaterialConsulta.Fields.Item("Name").Value;

            return listasMaterial;
        }

    }
}
