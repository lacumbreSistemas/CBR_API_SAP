using Domain.Models.Produccion;
using System;
using Intermedia_;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories.Transformaciones;
using Domain.Interfaces;

namespace Domain.Repositories.Transformaciones
{
    public class ProcesoTransformacionEntryBuildEstrategy: IModelEntryBuildProcesos
    {


        public ProcesosEntryModelBuild guardar(ProcesosEntryModelBuild procesosEntryModelBuild)
        {
            TransformacionEntryRepo transformacionEntryRepo = new TransformacionEntryRepo();
            cbr_TransformacionesEntry cbr_ProduccionEntry = new cbr_TransformacionesEntry();
            cbr_ProduccionEntry.cancelado = false;
            cbr_ProduccionEntry.deleted = false;
            cbr_ProduccionEntry.deletedId = 0;
            cbr_ProduccionEntry.fecha = (DateTime)DateTime.Now;
            cbr_ProduccionEntry.itemcode = procesosEntryModelBuild.codigoProducto;
            cbr_ProduccionEntry.numero = procesosEntryModelBuild.numero;
            cbr_ProduccionEntry.quantity = procesosEntryModelBuild.cantidad;
            cbr_ProduccionEntry.usuario = procesosEntryModelBuild.usuario;

            transformacionEntryRepo.crearDocumentoIntermedioProduccion(cbr_ProduccionEntry);
            return procesosEntryModelBuild;
        }


    }
}
