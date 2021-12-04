using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbr_ComprasSAP_Escaneo_Repository:MasterRespository
    {
      
        public double obtenerCantidadRecibida(int docEntry, string itemCode) 
        {
           var cantidad = db.cbr_ComprasSAP_Escaneo.Where(i => i.itemCode == itemCode && i.baseEntry == docEntry).Sum(i => i.cantidad);

            if(cantidad != null)
            {
                return (double) cantidad;
            } else
            {
                return 0;
            }
        }


        public List<cbr_ComprasSAP_Escaneo> ObteneDetalleEscaneos(int docEntry, string itemCode) {


            

            return null;
        }


        public void GuardarEscaneo(cbr_ComprasSAP_Escaneo Entry) {

            db.cbr_ComprasSAP_Escaneo.Add(Entry);
            db.SaveChanges();
            
        }
    }
}
