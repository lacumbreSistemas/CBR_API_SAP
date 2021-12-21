using Domain.Models;
using Domain.Models.ComrpasModels;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class EscaneoRepository
    {

        private EscaneoBuildNacionalEstrategia estrategia { get; set; }
        private cbr_ComprasSAP_Escaneo_Repository escaneosIntermedia { get; set; }


        public EscaneoRepository() {
          
            estrategia = new EscaneoBuildNacionalEstrategia();
            escaneosIntermedia = new cbr_ComprasSAP_Escaneo_Repository();
        }

        public EscaneoBuildModel Agregar(EscaneoBuildModel escaneo ) {

            EscaneoBuildModel Escaneo = new EscaneoBuildModel(escaneo, estrategia);
           return Escaneo.agreagar();
        
        }

        public List<EscaneoConsultaModel> obtenerHistorial(int docEntry, string ItemCode)
        {
            List<EscaneoConsultaModel> Historial = new List<EscaneoConsultaModel>();
            var escaneosHistorialIntermedia = escaneosIntermedia.ObtenerHistorialDeEscaneos(docEntry, ItemCode);

            escaneosHistorialIntermedia.ForEach(i=> {
                EscaneoConsultaModel historial = new EscaneoConsultaModel();
                historial.numeroOrdenDeCompra = i.baseEntry;
                historial.baseLine = i.baseLine;
                historial.cantidad = i.cantidad;
                historial.codigoProducto = i.itemCode;
                historial.fecha = i.fecha;
                historial.entradaMercanciaDocEntry = i.entradaMercanciaDocEntry;

                Historial.Add(historial);

            });


            return Historial;
        }


       public  EscaneoConsultaModel  anularEscaneo(int escaneo) {
        
             EscaneoConsultaModel es = new EscaneoConsultaModel(escaneo);


            EscaneoConsultaModel anulado = new EscaneoConsultaModel(es.Anular());

            return anulado; 

           
            
        
        }



    }
}
 