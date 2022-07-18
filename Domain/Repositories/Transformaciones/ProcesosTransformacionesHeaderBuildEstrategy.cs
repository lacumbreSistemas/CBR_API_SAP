using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_;
using Intermedia_.Repositories.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Transformaciones
{
    public class ProcesosTransformacionesHeaderBuildEstrategy : IModelHeaderBuildProcesos
    {

        public ProcesosModelBuild guardar(ProcesosModelBuild procesosModelBuild)
        {

            cbr_transformacionesHeader _cbr_transformacionesHeader = new cbr_transformacionesHeader();
            TransformacionesHeaderRepo TransformacionesRepo = new TransformacionesHeaderRepo();
            _cbr_transformacionesHeader.numero = procesosModelBuild.numero;
            _cbr_transformacionesHeader.comentario = procesosModelBuild.comentario;
            _cbr_transformacionesHeader.entradaDocEntry = 0;
            _cbr_transformacionesHeader.salidaDocEntry = 0;
            _cbr_transformacionesHeader.anulado = false;
            _cbr_transformacionesHeader.usuario = procesosModelBuild.usuario;
            _cbr_transformacionesHeader.whsCode = procesosModelBuild.codigoTienda;
            _cbr_transformacionesHeader.codigoProducto = procesosModelBuild.codigoProducto;
            _cbr_transformacionesHeader.fecha = procesosModelBuild.fechaCreacion;
            _cbr_transformacionesHeader.cantidad = procesosModelBuild.cantidad;
            _cbr_transformacionesHeader.remarkId = procesosModelBuild.remarkCode;
            procesosModelBuild.numero = TransformacionesRepo.crearDocumentoIntermedioTransformacion(_cbr_transformacionesHeader);

            return procesosModelBuild;

        }
    }
}
