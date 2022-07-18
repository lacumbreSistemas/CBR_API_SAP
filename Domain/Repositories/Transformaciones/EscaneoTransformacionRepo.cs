using Domain.Models.Produccion;
using Domain.Repositories.Produccion;
using Intermedia_.Repositories.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Transformaciones
{
   public class EscaneoTransformacionRepo
    {

        private TransformacionEntryRepo transformacionEntryRepo = new TransformacionEntryRepo();

        public ProcesosEntryModelBuild crearEntryProduccion(ProcesosEntryModelBuild newproduccionEntryModelBuild)
        {
            ProcesoTransformacionEntryBuildEstrategy estrategia = new ProcesoTransformacionEntryBuildEstrategy();
            ProcesosEntryModelBuild produccionEntryModelBuild = new ProcesosEntryModelBuild(newproduccionEntryModelBuild,estrategia);


            return produccionEntryModelBuild.guardar();
        }


        public List<ProcesosEntryModelConsulta> historialEntries(int number, string itemCode)
        {

            List<ProcesosEntryModelConsulta> historialEntries = new List<ProcesosEntryModelConsulta>();

            transformacionEntryRepo.obtenerEntriesPorNumberItemCode(number, itemCode).ForEach(i => {

                ProcesosEntryModelConsulta entrie = new ProcesosEntryModelConsulta();

                entrie.cantidad = (double)i.quantity;
                entrie.deleted = i.deleted;
                entrie.deletedId = i.deletedId;
                entrie.fecha = (DateTime)i.fecha;
                entrie.id = i.id;
                entrie.codigoProducto = i.itemcode;
                entrie.numero = (int)i.numero;
                entrie.usuario = i.usuario;
                entrie.setNombreProducto();

                historialEntries.Add(entrie);

            });

            return historialEntries;
        }

        public ProcesosEntryModelConsulta anularEscaneo(ProcesosEntryModelConsulta procesoEntryModelConsulta)
        {
            ProcesoTransformacionEntryConsultaEstrategy estrategia = new ProcesoTransformacionEntryConsultaEstrategy();
            procesoEntryModelConsulta.Estrategia = estrategia;
            return procesoEntryModelConsulta.anular();

        }


    }
}
