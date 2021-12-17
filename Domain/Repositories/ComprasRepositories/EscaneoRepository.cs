using Domain.Models;
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
        private cbr_ComprasSAP_Escaneo_Repository escaneosIntermedia;


        public EscaneoRepository() {

            escaneosIntermedia = new cbr_ComprasSAP_Escaneo_Repository();
        
        }

        public EscaneoBuildModel Agregar(EscaneoBuildModel escaneo ) {

            EscaneoBuildModel Escaneo = new EscaneoBuildModel(escaneo);
           return Escaneo.agreagar();
        
        }


        

    

      
        
    }
}
