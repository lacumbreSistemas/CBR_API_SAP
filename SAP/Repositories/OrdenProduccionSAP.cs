using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
   public class OrdenProduccionSAP
    {

        MasterRepository _MasterRepository = MasterRepository.GetInstance();


        public void generarOrdenProduccion() {
            Documents solicitudDevolicion = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
           
            Document_Lines lines = solicitudDevolicion.Lines;
          
            lines.BaseEntry = 11198;
            lines.Quantity = 1;
            lines.Price = 23.3;
            lines.Add();

          int i =  solicitudDevolicion.Add();

            string nuevaSolicitudDevolucion;
            if (i == 0)
            {

                nuevaSolicitudDevolucion = _MasterRepository.connection.GetNewObjectKey();
            }
            else {
                nuevaSolicitudDevolucion = _MasterRepository.connection.GetLastErrorDescription();
            }

        }
    }
}
