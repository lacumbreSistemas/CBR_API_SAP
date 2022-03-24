using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Models.SolicitudDevolicionEntrys;
using SAPbobsCOM;

namespace SAP.Repositories.SolicitudesDevoliciones
{
    public class SolicitudesDevolucionesRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();
      

        public int generarSolicitudDevolicion(SolicitudDevolucionSAPEntity solicitudDevolucionHeaderSAPEntity) {
          


          int siDocumentoAgregado = 0;
          string nuevaSolicitudDevolucion = "";
            string tienda = solicitudDevolucionHeaderSAPEntity.WhsCode;
     




            Documents solicitudDevolicion = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oGoodsReturnRequest);
            solicitudDevolicion.CardCode = solicitudDevolucionHeaderSAPEntity.CardCode;
            solicitudDevolicion.UserFields.Fields.Item("U_tiedest").Value = tienda;
            solicitudDevolicion.Comments = solicitudDevolucionHeaderSAPEntity.Comentario;
            
           
            solicitudDevolicion.SalesPersonCode = solicitudDevolucionHeaderSAPEntity.codigoPersonaCompras;

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


        public int obtenerDocnum(int Docentry)
        {
          var docNumConsulta =   _MasterRepository.doQuery("select Docnum from OPRR where docentry ="+Docentry);
            docNumConsulta.MoveFirst();

            int docNum = docNumConsulta.Fields.Item("Docnum").Value;
            return docNum;
        }
    }
}
