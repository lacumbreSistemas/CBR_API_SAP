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
  

        public int id { get; set; } 

        public int entradaMercanciaDocEntry { get; set; } 

        public bool elimnado { get; set; }

        public int escaneoAnuladoID { get; set; }
        // private 

        private cbr_ComprasSAP_Escaneo_Repository ComprasSAPEscaneoRepository { get; set; }

        public EscaneoConsultaModel() {

            ComprasSAPEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();
        
        }

        public EscaneoConsultaModel(int id)
        {
            this.id = id;
            ComprasSAPEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();

            obtenerEscaneoporID();
           
            ComprasSAPEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();

        }

        private void obtenerEscaneoporID() {

            ComprasSAPEscaneoRepository.obtenerEscaneoPorID(id);
        }


        public void establercerEntradaMercancia(int DocEntryEM) {

            ComprasSAPEscaneoRepository.guardadoEntradaMercancia(this.numeroOrdenDeCompra, this.codigoProducto, this.entradaMercanciaDocEntry); 

        }

        public int Anular() {
         return  ComprasSAPEscaneoRepository.borrarEscaneo(this.id);
        }

      




    }
}
