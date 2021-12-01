using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Repositories; 

namespace Domain.Models
{
    class EscaneoModel
    {

        //public
        public int documentoBase { get; set; }
        public string codigoProducto { get; set; }

        public string usuario { get; set; }
        public string cantidad { get; set; }

        public string fecha { get; set; }

        public string entradaMercancia { get; set; }

        //privaate

             private cbr_ComprasSAP_Escaneo_Repository intermediaEntryRepository { get; set; }


        //constructores
        public EscaneoModel() { 
        
        }

       
       public EscaneoModel(EscaneoModel newEscaneo) {

            documentoBase = newEscaneo.documentoBase;
            codigoProducto = newEscaneo.codigoProducto;
            usuario = newEscaneo.usuario;
            cantidad = newEscaneo.cantidad;
            fecha = newEscaneo.fecha;
            entradaMercancia = newEscaneo.entradaMercancia;

            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
        
        }

        //metodos
                public void agreagar() {
    
                     double cantidadOrdenada = intermediaEntryRepository.GetItemReceived();

        
                }

    }
}
