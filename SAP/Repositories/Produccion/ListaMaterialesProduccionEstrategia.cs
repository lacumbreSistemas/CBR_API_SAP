using SAP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Produccion
{
   public  class ListaMaterialesProduccionEstrategia: IListaMaterialesSAP
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();

        public List<ListaMaterialEntity> obtenerListasMateriales()
        {
            var recetas = _MasterRepository.doQuery("select code,Name from oitt where u_tipo_Produccion = 1");
            List<ListaMaterialEntity> listasMateriales = new List<ListaMaterialEntity>();

            while (!recetas.EoF)
            {
                ListaMaterialEntity listaMaterialEntity = new ListaMaterialEntity();
                listaMaterialEntity.Code = recetas.Fields.Item("code").Value;
                listaMaterialEntity.Name = recetas.Fields.Item("Name").Value;

                listasMateriales.Add(listaMaterialEntity);

                recetas.MoveNext();
            }

            return listasMateriales;
        }
    }
}
