using Domain.Interfaces;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EscaneoConsultaModel : EscaneoMasterModel
    {
  

     

        public int DocEntryEM { get; set; } 
        // private 

        private cbr_ComprasSAP_Escaneo_Repository escaneosIntermedia { get; set; };

        public EscaneoConsultaModel() {

            escaneosIntermedia = new cbr_ComprasSAP_Escaneo_Repository();
        
        }


        public void establercerEntradaMercancia(int docEntry) {

            escaneosIntermedia.guardadoEntradaMercancia(this.numeroOrdenDeCompra, this.codigoProducto, this.DocEntryEM);
                

        }

      




    }
}
