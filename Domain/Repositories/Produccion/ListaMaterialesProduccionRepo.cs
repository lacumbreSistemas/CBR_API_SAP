using Domain.Models.Produccion;
using SAP.Models.Produccion;
using SAP.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
  public  class ListaMaterialesProduccionRepo
    {
        public List<ListaMaterialesModel> obtenerListaMateriales() {
            ListaMaterialesProduccionEstrategia estrategia = new ListaMaterialesProduccionEstrategia();
            ListaMaterialProduccionRepoSAP listaMaterialRepoSAP = new ListaMaterialProduccionRepoSAP(estrategia);
            List<ListaMaterialesModel> ListaMateriales = new List<ListaMaterialesModel>();


             var listaMaterialesSAP =    listaMaterialRepoSAP.obtenerListasMateriales();

            listaMaterialesSAP.ForEach(i => {
                ListaMaterialesModel listaMateriales = new ListaMaterialesModel();

                listaMateriales.code = i.Code;
                listaMateriales.descriptionReceta = i.Name;
                ListaMateriales.Add(listaMateriales); 
            });


            return ListaMateriales;

        }


        public List<ListaMaterialesEntryModel> obtenerListaMaterialesCode(string code)
        {
            ListaMaterialesProduccionEstrategia estrategia = new ListaMaterialesProduccionEstrategia();
            ListaMaterialProduccionRepoSAP listaMaterialRepoSAP = new ListaMaterialProduccionRepoSAP(estrategia); 
          List<ListaMaterialesEntryModel> listaMaterialesEntries = new List<ListaMaterialesEntryModel>();


            var listaMaterialesSAP = listaMaterialRepoSAP.obtenerListaMaterialesDetalle(code);

            listaMaterialesSAP.ForEach(i=> {
                ListaMaterialesEntryModel listaMaterialesEntryModel = new ListaMaterialesEntryModel();
                listaMaterialesEntryModel.code = i.Code;
                listaMaterialesEntryModel.descriptionListaMateriales = i.Name;
                listaMaterialesEntries.Add(listaMaterialesEntryModel);
            });

            return listaMaterialesEntries;

        }

    }
}
