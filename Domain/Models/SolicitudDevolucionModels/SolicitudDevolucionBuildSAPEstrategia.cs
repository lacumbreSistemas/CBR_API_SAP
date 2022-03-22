using Domain.Interfaces;
using SAP.Models.SolicitudDevolicionEntrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionBuildSAPEstrategia : SolicitudDevolucionModelBuildEstrategia
    {
        public SolicitudDevolucionModelBuild guardar(SolicitudDevolucionModelBuild solicitudDevolucionModelBuild) {

            SolicitudDevolucionSAPEntity solicitudDevolucionSAPEntity = new SolicitudDevolucionSAPEntity();

            solicitudDevolucionSAPEntity.CardCode = solicitudDevolucionModelBuild.codigoProveedor;
            solicitudDevolucionSAPEntity.WhsCode = solicitudDevolucionModelBuild.codigoTienda; 
           


            return solicitudDevolucionModelBuild;
        }
    }
}

