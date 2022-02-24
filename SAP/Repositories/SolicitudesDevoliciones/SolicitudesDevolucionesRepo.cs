using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPbobsCOM;

namespace SAP.Repositories.SolicitudesDevoliciones
{
    public class SolicitudesDevolucionesRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();


        public void generarSolicitudDevolicion() {

            int siDocumentoAgregado = 0;
            string numeroNuevaSolicitudDevolucion = "";


            Documents solicitudDevolicion = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oGoodsReturnRequest);
            //solicitudDevolicion.CardCode = 



        }
        
    }
}
