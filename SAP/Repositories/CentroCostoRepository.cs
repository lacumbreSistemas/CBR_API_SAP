using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
   public class CentroCostoRepository
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();
        public CentroCostoEntity obtenerCentroCostoporCode(string code) {

            var consultarCentroCosto = _MasterRepository.doQuery("select  OcrCode,OcrName  from OOCR where OcrCode = "+code);

            consultarCentroCosto.MoveFirst();
            CentroCostoEntity centroCosto = new CentroCostoEntity();

            centroCosto.code = consultarCentroCosto.Fields.Item("OcrCode").Value;
            centroCosto.OcrName = consultarCentroCosto.Fields.Item("OcrName").Value;

            return centroCosto; 
        }
    }
}
