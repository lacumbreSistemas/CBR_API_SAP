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

        public List<cbr_ComprasSAP_Escaneo> ObtenerHistorialDeEscaneos(int docEntry, string itemCode) {

    
            return db.cbr_ComprasSAP_Escaneo.Where(i => i.baseEntry == docEntry && i.itemCode == itemCode).ToList(); 
        }


        public List<cbr_ComprasSAP_Escaneo> ObtenerEscaneosPorDocEntrySinIngresarSAP(int docEntry) {

            List<cbr_ComprasSAP_Escaneo> Escaneos = db.cbr_ComprasSAP_Escaneo.Where(i => i.baseEntry == docEntry && i.entradaMercanciaDocEntry == 0).ToList();
  
            return Escaneos;
        }

        public List<cbr_ComprasSAP_Escaneo> ObtenerEscaneosPorDocEntryTodos(int docEntry)
        {

            List<cbr_ComprasSAP_Escaneo> Escaneos = db.cbr_ComprasSAP_Escaneo.Where(i => i.baseEntry == docEntry ).ToList();



            return Escaneos;
        }


        public void GuardarEscaneo(cbr_ComprasSAP_Escaneo Entry) {

            db.cbr_ComprasSAP_Escaneo.Add(Entry);
            db.SaveChanges();
            
        }


        public void establecerEntradaMercanciaPorRango(int baseEntry, string itemCode, int DocentryEM) {

            var itemEscaneos = db.cbr_ComprasSAP_Escaneo.Where(i => i.baseEntry == baseEntry && i.itemCode == itemCode).ToList();
            itemEscaneos.ForEach(escaneo =>
            {
                escaneo.entradaMercanciaDocEntry = DocentryEM;
                db.SaveChanges();
            });

        }


        public cbr_ComprasSAP_Escaneo obtenerEscaneoPorID(int id) {

            return db.cbr_ComprasSAP_Escaneo.FirstOrDefault(i=> i.id == id);
        
        
        }


        public int borrarEscaneo(int id) {
            var escaneo = db.cbr_ComprasSAP_Escaneo.FirstOrDefault(i=> i.id == id);
            escaneo.deleted = true;

            cbr_ComprasSAP_Escaneo escaneoNegativo = new cbr_ComprasSAP_Escaneo();

            escaneoNegativo.baseEntry = escaneo.baseEntry;
            escaneoNegativo.baseLine = escaneo.baseLine;
            escaneoNegativo.cantidad = escaneo.cantidad;
            escaneoNegativo.deleted = false;
            escaneoNegativo.entradaMercanciaDocEntry = 0;
            escaneoNegativo.escaneoAnuladoID = escaneo.id;
            escaneoNegativo.fecha = DateTime.Now;
            escaneoNegativo.itemCode= escaneo.itemCode;
            escaneoNegativo.cantidad = escaneoNegativo.cantidad * (-1);
 


            db.cbr_ComprasSAP_Escaneo.Add(escaneoNegativo);
            db.SaveChanges();

            return escaneoNegativo.id;

        }



    }
}
