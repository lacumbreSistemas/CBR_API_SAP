using SAP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Produccion
{
    public class ListaMaterialRepo
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

                recetas.MoveFirst();
            }

            return listasMateriales;

        }

        public List<ListaMaterialesDetalleEntity> obtenerListaMaterialesDetalle(string code) {

            var recetas = _MasterRepository.doQuery("select code,ItemName from oitt where Father ='"+code+"'");
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

    }
}
