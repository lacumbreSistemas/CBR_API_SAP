using Domain.Models.Produccion;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class EscaneoProduccionRepo
    {
        private ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

        public ProduccionEntryModelBuild crearEntryProduccion(ProduccionEntryModelBuild newproduccionEntryModelBuild) {
            ProduccionEntryModelBuild produccionEntryModelBuild = new ProduccionEntryModelBuild(newproduccionEntryModelBuild);


            return produccionEntryModelBuild.guardar();
        }
        public List<ProduccionEntryModelConsulta> historialEntries(int number, string itemCode)
        {

            List<ProduccionEntryModelConsulta> historialEntries = new List<ProduccionEntryModelConsulta>();

            produccionEntryRepo.obtenerEntriesPorNumberItemCode(number, itemCode).ForEach(i => {

                ProduccionEntryModelConsulta entrie = new ProduccionEntryModelConsulta();

                entrie.cantidad = (double)i.quantity;
                entrie.deleted = i.deleted;
                entrie.deletedId = i.deletedId;
                entrie.fecha = i.fecha;
                entrie.id = i.id;
                entrie.codigoProducto = i.itemcode;
                entrie.numero = (int)i.numero;
                entrie.usuario = i.usuario;
                entrie.setNombreProducto();

                historialEntries.Add(entrie);

            });

            return historialEntries;
        }

        public ProduccionEntryModelConsulta anularEscaneo(ProduccionEntryModelConsulta produccionEntryModelConsulta)
        {

            return produccionEntryModelConsulta.anular();

        }


    }
}
