using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using Intermedia_;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionBuildIntermediaEstrategia :SolicitudDevolucionModelBuildEstrategia
    {
        public SolicitudDevolucionModelBuild guardar(SolicitudDevolucionModelBuild solicitudDevolucionModelBuild)
        {
            cbr_SolicitudDevolucionHeader _solicitudDevolucionHeader = new cbr_SolicitudDevolucionHeader();
            cbr_SolicitudDevolucionHeaderRepo solicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();

            _solicitudDevolucionHeader.cardCode = solicitudDevolucionModelBuild.codigoProveedor;
            _solicitudDevolucionHeader.whsCode = solicitudDevolucionModelBuild.codigoTienda;
            _solicitudDevolucionHeader.fecha = solicitudDevolucionModelBuild.fechaCreacion;
            _solicitudDevolucionHeader.number = solicitudDevolucionModelBuild.numeroDevolucion;
            _solicitudDevolucionHeader.comentario = solicitudDevolucionModelBuild.comentario;
            _solicitudDevolucionHeader.anulado = false;

            var nuevaSolicitudDevolucion =  solicitudDevolucionHeaderRepo.crearCbr_SolicitudDevolucionHeader(_solicitudDevolucionHeader);

            solicitudDevolucionModelBuild.numeroDevolucion = nuevaSolicitudDevolucion;

            return solicitudDevolucionModelBuild;
        }

    }
}
