using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbr_ComprasSAP_Escaneo_Repository:MasterRespository
    {
      
        public double obtenerCantidadRecibida(int? docEntry, string itemCode) 
        {
           var cantidad = db.cbr_ComprasSAP_Escaneo.Where(i => i.itemCode == itemCode && i.baseEntry == docEntry).ToList().Sum(i => i.cantidad);

            if(cantidad != null)
            {
                return (double) cantidad;
            } else
            {
                return 0;
            }
        }


        public List<cbr_ComprasSAP_Escaneo> ObtenerEscaneosPorDocEntry(int docEntry) {

            List<cbr_ComprasSAP_Escaneo> Escaneos = db.cbr_ComprasSAP_Escaneo.Where(i => i.baseEntry == docEntry && i.entradaMercanciaDocEntry == 0).ToList();
   
          

            return Escaneos;
        }




        public void GuardarEscaneo(cbr_ComprasSAP_Escaneo Entry) {

            db.cbr_ComprasSAP_Escaneo.Add(Entry);
            db.SaveChanges();
            
        }


        public void guardadoEntradaMercancia(int baseEntry, string itemCode, int DocentryEM) {

            var itemEscaneos = db.cbr_ComprasSAP_Escaneo.FirstOrDefault(i => i.baseEntry == baseEntry && i.itemCode == itemCode);
            itemEscaneos.entradaMercanciaDocEntry = DocentryEM;

            db.SaveChanges();
           
        
        }



    }
}
