using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_.Repositories.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Transformaciones
{
    public class ProcesosTransformacionesHeaderConsultaEstrategy : IModelHeaderConsultaProcesos
    {
        public ProcesosModelConsulta obtenerHeader(int numero)
        {
            ProcesosModelConsulta procesosModelConsulta = new ProcesosModelConsulta();

            TransformacionesHeaderRepo headerRepo = new TransformacionesHeaderRepo();

            var documentoproducion = headerRepo.obtenerDocumentoIntermedioTransformacion(numero);
            procesosModelConsulta.codigoTienda = documentoproducion.whsCode;
            procesosModelConsulta.codigoProducto = documentoproducion.codigoProducto;
            procesosModelConsulta.usuario = documentoproducion.usuario;
            procesosModelConsulta.comentario = documentoproducion.comentario;
            procesosModelConsulta.fechaCreacion = (DateTime) documentoproducion.fecha;
            procesosModelConsulta.remarkCode = documentoproducion.remarkId;
            procesosModelConsulta.cantidad = documentoproducion.cantidad;

            return procesosModelConsulta;
        }

        public List<ProduccionEntryResumenConsulta> resumenEntries(int numero)
        {
            List<ProduccionEntryResumenConsulta> entries = new List<ProduccionEntryResumenConsulta>();
            TransformacionEntryRepo produccionEntryRepo = new TransformacionEntryRepo();
            produccionEntryRepo.obtenerEntriesPornumber(numero).Where(i => (bool) !i.cancelado).GroupBy(i => new { i.numero, i.itemcode }).ToList().ForEach(i =>
            {
                ProduccionEntryResumenConsulta produccionModelConsulta = new ProduccionEntryResumenConsulta(i.FirstOrDefault().itemcode);
                produccionModelConsulta.numero = numero;
                produccionModelConsulta.cantidadEscaneada = i.Sum(i => (double)i.quantity);
                entries.Add(produccionModelConsulta);
            });

            return entries;
        }
    }
}
