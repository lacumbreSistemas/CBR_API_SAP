using SAP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
   public class ListaMeterialesRepo
    {

        MasterRepository _MasterRepository = MasterRepository.GetInstance();

        public List<ListaMaterialEntity> obtenerListaMeteriales()
        {

            var listaMeterialesConsulta = _MasterRepository.doQuery("select code,[name] from oitt");

            List<ListaMaterialEntity> ListasMateriales = new List<ListaMaterialEntity>();

            ListaMaterialEntity listaMateriales = new ListaMaterialEntity();

            while (!listaMeterialesConsulta.EoF) {

                listaMateriales.Code = listaMeterialesConsulta.Fields.Item("code").Value;
                listaMateriales.Name = listaMeterialesConsulta.Fields.Item("[name]").Value;
                ListasMateriales.Add(listaMateriales);
                listaMeterialesConsulta.MoveNext();
            }

            return ListasMateriales;

        }


        public ListaMaterialesDetalleEntity obtenerListaMeterialesCode(string code)
        {

            var listaMeterialesConsulta = _MasterRepository.doQuery("select code,[name] from oitt where code = '"+code+"'");

          

            ListaMaterialesDetalleEntity listaMateriales = new ListaMaterialesDetalleEntity();

            listaMeterialesConsulta.MoveFirst();

            listaMateriales.Code = listaMeterialesConsulta.Fields.Item("code").Value;
            listaMateriales.Name = listaMeterialesConsulta.Fields.Item("[name]").Value;


            return listaMateriales;

        }

    }
}
