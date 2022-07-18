using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class ProcesoProduccionHeaderBuildEstrategy: IModelHeaderBuildProcesos
    {

        public ProcesosModelBuild guardar(ProcesosModelBuild procesosModelBuild)
        {

            cbr_ProduccionHeader _cbr_ProduccionHeader = new cbr_ProduccionHeader();
            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            _cbr_ProduccionHeader.numero = procesosModelBuild.numero;
            _cbr_ProduccionHeader.comentario = procesosModelBuild.comentario;
            _cbr_ProduccionHeader.entradaDocEntry = 0;
            _cbr_ProduccionHeader.salidaDocEntry = 0;
            _cbr_ProduccionHeader.anulado = false;
            _cbr_ProduccionHeader.usuario = procesosModelBuild.usuario;
            _cbr_ProduccionHeader.whsCode = procesosModelBuild.codigoTienda;
            _cbr_ProduccionHeader.codigoProducto = procesosModelBuild.codigoProducto;
            _cbr_ProduccionHeader.fecha = procesosModelBuild.fechaCreacion;
            _cbr_ProduccionHeader.cantidad = procesosModelBuild.cantidad;
            _cbr_ProduccionHeader.remarkId = procesosModelBuild.remarkCode;
            procesosModelBuild.numero = produccionHeaderRepo.crearDocumentoIntermedioProduccion(_cbr_ProduccionHeader);

            return procesosModelBuild;

        }

       
    }
}
