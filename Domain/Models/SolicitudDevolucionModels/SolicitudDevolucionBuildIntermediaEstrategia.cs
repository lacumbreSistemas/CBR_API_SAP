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
        public SolicitudDevolucionModelBuild guardar(SolicitudDevolucionModelBuild solicitudDevolucionModelBuild) {
            cbr_SolicitudDevolucionHeader _solicitudDevolucionHeader = new cbr_SolicitudDevolucionHeader();
            cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();

            _solicitudDevolucionHeader.cardCode = solicitudDevolucionModelBuild.ProveedorCode;
            _solicitudDevolucionHeader.whsCode = solicitudDevolucionModelBuild.TiendaCode;

            _solicitudDevolucionHeader.fecha = solicitudDevolucionModelBuild.Fecha;
            _solicitudDevolucionHeader.number = solicitudDevolucionModelBuild.Numero;
            _solicitudDevolucionHeader.comentario = solicitudDevolucionModelBuild.Comentario;
            _solicitudDevolucionHeader.anulado = false;

            solicitudDevolucionModelBuild.Numero = _SolicitudDevolucionHeaderRepo.crearCbr_SolicitudDevolucionHeader(_solicitudDevolucionHeader);

            return solicitudDevolucionModelBuild;
        }


    }
}
