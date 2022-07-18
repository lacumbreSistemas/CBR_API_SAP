using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
   public class ProcesoProduccionHeaderConsultaEstrategy: IModelHeaderConsultaProcesos
    {
  
        public ProcesosModelConsulta obtenerHeader(int numero)
        {
            ProcesosModelConsulta procesosModelConsulta = new ProcesosModelConsulta();

            ProduccionHeaderRepo headerRepo = new ProduccionHeaderRepo();

            var documentoproducion = headerRepo.obtenerDocumentoIntermedioProduccion(numero);
            procesosModelConsulta.codigoTienda = documentoproducion.whsCode;
            procesosModelConsulta.codigoProducto = documentoproducion.codigoProducto;
            procesosModelConsulta.usuario = documentoproducion.usuario;
            procesosModelConsulta.comentario = documentoproducion.comentario;
            procesosModelConsulta.fechaCreacion = documentoproducion.fecha;
            procesosModelConsulta.remarkCode = documentoproducion.remarkId;
            procesosModelConsulta.cantidad = documentoproducion.cantidad;

            return procesosModelConsulta;

        }
        public List<ProduccionEntryResumenConsulta> resumenEntries(int numero)
        {

            List<ProduccionEntryResumenConsulta> entries = new List<ProduccionEntryResumenConsulta>();
            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();
            produccionEntryRepo.obtenerEntriesPornumber(numero).Where(i => !i.cancelado).GroupBy(i => new { i.numero, i.itemcode }).ToList().ForEach(i =>
            {
                ProduccionEntryResumenConsulta produccionModelConsulta = new ProduccionEntryResumenConsulta(i.FirstOrDefault().itemcode);
                produccionModelConsulta.numero = numero;
                produccionModelConsulta.cantidadEscaneada = i.Sum(i => i.quantity);
                entries.Add(produccionModelConsulta);
            });

            return entries;
        }
     }
}
