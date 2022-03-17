using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Models.SolicitudDevolicionEntrys;
using SAPbobsCOM;

namespace SAP.Repositories.SolicitudesDevoliciones
{
    public class SolicitudesDevolucionesRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();
      

        public int generarSolicitudDevolicion(SolicitudDevolucionHeaderSAPEntity solicitudDevolucionHeaderSAPEntity) {

          int siDocumentoAgregado = 0;
       string nuevaSolicitudDevolucion = "";


            Documents solicitudDevolicion = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oGoodsReturnRequest);
            solicitudDevolicion.CardCode = solicitudDevolucionHeaderSAPEntity.CardCode;
            solicitudDevolicion.UserFields.Fields.Item("U_tiedest").Value = solicitudDevolucionHeaderSAPEntity.WhsCode;

            solicitudDevolucionHeaderSAPEntity.solicitudDevolucionEntrySAPEntities.ForEach(i=> {
                Document_Lines solicitudDevolicionLines = solicitudDevolicion.Lines;
                solicitudDevolicionLines.ItemCode = i.ItemCode;
                solicitudDevolicionLines.Quantity = i.Cantidad;

                solicitudDevolicionLines.Add();
            });


            siDocumentoAgregado = solicitudDevolicion.Add();

            if (siDocumentoAgregado == 0)
            {

                nuevaSolicitudDevolucion = _MasterRepository.connection.GetNewObjectKey();
                return Convert.ToInt32(nuevaSolicitudDevolucion);

            }
            throw new Exception("Entrada de mercancía Error [" + _MasterRepository.connection.GetLastErrorDescription() + "] ");
        }
        
    }
}
