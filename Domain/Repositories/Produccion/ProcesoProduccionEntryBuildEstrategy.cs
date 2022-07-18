using Domain.Models.Produccion;
using Intermedia_.Repositories.Produccion;
using Intermedia_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Repositories.Produccion
{
   public class ProcesoProduccionEntryBuildEstrategy: IModelEntryBuildProcesos
    {

        public ProcesosEntryModelBuild guardar(ProcesosEntryModelBuild procesosEntryModelBuild)
        {
            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();
            cbr_ProduccionEntry cbr_ProduccionEntry = new cbr_ProduccionEntry();
            cbr_ProduccionEntry.cancelado = false;
            cbr_ProduccionEntry.deleted = false;
            cbr_ProduccionEntry.deletedId = 0;
            cbr_ProduccionEntry.fecha = (DateTime)DateTime.Now;
            cbr_ProduccionEntry.itemcode = procesosEntryModelBuild.codigoProducto;
            cbr_ProduccionEntry.numero = procesosEntryModelBuild.numero;
            cbr_ProduccionEntry.quantity = procesosEntryModelBuild.cantidad;
            cbr_ProduccionEntry.usuario = procesosEntryModelBuild.usuario;

            produccionEntryRepo.crearDocumentoIntermedioProduccion(cbr_ProduccionEntry);
            return procesosEntryModelBuild;
        }
    }
}
