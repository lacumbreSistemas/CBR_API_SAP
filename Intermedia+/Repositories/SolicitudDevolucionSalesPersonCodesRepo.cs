using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class SolicitudDevolucionSalesPersonCodesRepo:MasterRespository 
    {

        public int  obtenerSolicitudDevolucionSalesPersonCode(string WhsCode) {

            var code = db.SolicitudDevolucionSalesPersonCodes.FirstOrDefault(i=> i.tienda == WhsCode);

            return code == null ? -1 : (int) code.codigo;
        }
    }
}
