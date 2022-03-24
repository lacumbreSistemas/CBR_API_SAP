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
        public int DocNum { get; set; }
      

        public List<SolicitudDevolucionEntryResumenMaster> _solicitudDevolucionEntryResumenList = new List<SolicitudDevolucionEntryResumenMaster>();


        public SolicitudDevolucionModelSAP() {

            
        }

        public SolicitudDevolucionModelSAP generarSolicitudDevolucion() 
        {


            SolicitudDevolucionSalesPersonCodesRepo solicitudDevolucionSalesPersonCodesRepo = new SolicitudDevolucionSalesPersonCodesRepo();
            SolicitudDevolucionSAPEntity solicitudDevolucionSAP = new SolicitudDevolucionSAPEntity();
            SolicitudesDevolucionesRepo solicitudesDevolucionesRepo = new SolicitudesDevolucionesRepo();
            cbr_SolicitudDevolucionHeaderRepo solicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
            solicitudDevolucionSAP.CardCode = codigoProveedor;
            solicitudDevolucionSAP.WhsCode = codigoTienda;
            solicitudDevolucionSAP.Comentario = comentario;
            solicitudDevolucionSAP.codigoPersonaCompras = solicitudDevolucionSalesPersonCodesRepo.obtenerSolicitudDevolucionSalesPersonCode(codigoTienda);

            _solicitudDevolucionEntryResumenList.ForEach(i =>
            {

                SolicitudDevolucionEntrySAPEntity solicitudDevolucionEntrySAPEntity = new SolicitudDevolucionEntrySAPEntity();
                solicitudDevolucionEntrySAPEntity.ItemCode = i.CodigoProducto;
                solicitudDevolucionEntrySAPEntity.Cantidad = (double)i.CantidadEscaneada; ;

                solicitudDevolucionSAP.solicitudDevolucionEntrySAPEntities.Add(solicitudDevolucionEntrySAPEntity);

            });

            DocEntry = solicitudesDevolucionesRepo.generarSolicitudDevolicion(solicitudDevolucionSAP);

            DocNum = solicitudesDevolucionesRepo.obtenerDocnum(DocEntry);

            solicitudDevolucionHeaderRepo.setDocEntry(numeroDevolucion,DocEntry);


            return this;
        }



    }
}
