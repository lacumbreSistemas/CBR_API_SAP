using Intermedia_.Repositories;
using SAP.Models.SolicitudDevolicionEntrys;
using SAP.Repositories.SolicitudesDevoliciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
   public class SolicitudDevolucionModelSAP: SolicitudDevolucionModelMaster
    {
        public int DocEntry { get; set; }

        public List<SolicitudDevolucionEntryResumenMaster> _solicitudDevolucionEntryResumenList = new List<SolicitudDevolucionEntryResumenMaster>();


        public SolicitudDevolucionModelSAP() {

            
        }

        public SolicitudDevolucionModelSAP generarSolicitudDevolucion() 
        { 
        


            SolicitudDevolucionSAPEntity solicitudDevolucionSAP = new SolicitudDevolucionSAPEntity();
            SolicitudesDevolucionesRepo solicitudesDevolucionesRepo = new SolicitudesDevolucionesRepo();
            cbr_SolicitudDevolucionHeaderRepo solicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
            solicitudDevolucionSAP.CardCode = codigoProveedor;
            solicitudDevolucionSAP.WhsCode = codigoTienda;

            _solicitudDevolucionEntryResumenList.ForEach(i =>
            {

                SolicitudDevolucionEntrySAPEntity solicitudDevolucionEntrySAPEntity = new SolicitudDevolucionEntrySAPEntity();
                solicitudDevolucionEntrySAPEntity.ItemCode = i.CodigoProducto;
                solicitudDevolucionEntrySAPEntity.Cantidad = (double)i.CantidadEscaneada;

                solicitudDevolucionSAP.solicitudDevolucionEntrySAPEntities.Add(solicitudDevolucionEntrySAPEntity);

            });

            DocEntry = solicitudesDevolucionesRepo.generarSolicitudDevolicion(solicitudDevolucionSAP);

            solicitudDevolucionHeaderRepo.setDocEntry(numeroDevolucion,DocEntry);


            return this;
        }



    }
}
