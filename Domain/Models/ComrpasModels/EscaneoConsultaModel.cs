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

        public int? entradaMercanciaDocEntry { get; set; } 

        public bool elimnado { get; set; }

        public int escaneoAnuladoID { get; set; }
        // private 

        private cbr_ComprasSAP_Escaneo_Repository ComprasSAPEscaneoRepository { get; set; }


        public EscaneoConsultaModel() {
            ComprasSAPEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();
        }

        public EscaneoConsultaModel(int id)
        {
            ComprasSAPEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();

            obtenerEscaneoporID(id);
       

        }

       private void obtenerEscaneoporID(int id) {

          var escaneo = ComprasSAPEscaneoRepository.obtenerEscaneoPorID(id);
            this.id = escaneo.id;
            this.fecha = escaneo.fecha;
            this.escaneoAnuladoID = escaneo.escaneoAnuladoID;
            this.elimnado = escaneo.deleted;
            this.entradaMercanciaDocEntry = escaneo.entradaMercanciaDocEntry;
            this.codigoProducto = escaneo.itemCode;
            this.baseLine = escaneo.baseLine;
            this.cantidad = escaneo.cantidad;
            this.setNombreProducto();
            this.ordenCompraDocEntry = escaneo.baseEntry;
            this.usuario = escaneo.nombreUsuario;
  

        }


        //public void establercerEntradaMercancia() {

        //    ComprasSAPEscaneoRepository.establecerEntradaMercanciaAEscaneo(this.id,  this.entradaMercanciaDocEntry); 

        //}

        public int Anular() {
            if (this.elimnado)
            {
                throw new Exception("Este escaneo ya fue eliminado");
            }

            if (this.entradaMercanciaDocEntry != 0)
            {
                throw new Exception("No puede eliminar este escaneo porque ya fue ingresado en la entrada de mercancia: " + this.entradaMercanciaDocEntry);
            }

            return  ComprasSAPEscaneoRepository.borrarEscaneo(this.id);
        }

      




    }
}
