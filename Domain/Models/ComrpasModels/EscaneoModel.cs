using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Repositories;
using Intermedia_;
 

namespace Domain.Models
{
   public class EscaneoModel
    {

        //public
        public int numeroOrdenDeCompra { get; set; }
        public string codigoProducto { get; set; }

        public int usuario { get; set; }
        public double cantidad { get; set; }

        public DateTime? fecha { get; set; }

        public int numeroEntradaDeMercancía { get; set; }

        //privaate

              private cbr_ComprasSAP_Escaneo_Repository intermediaEscaneoRepository { get; set; }
              private PurchaseOrderEntryRespository sapEntryRepository { get; set; }

        //constructores
        public EscaneoModel( ) { 
        
        }

       
       public EscaneoModel(EscaneoModel newEscaneo) {

            numeroOrdenDeCompra = newEscaneo.numeroOrdenDeCompra;
            codigoProducto = newEscaneo.codigoProducto;
            usuario = newEscaneo.usuario;
            cantidad = newEscaneo.cantidad;
            fecha = DateTime.Now;
            numeroEntradaDeMercancía = newEscaneo.numeroEntradaDeMercancía;

            intermediaEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();
            sapEntryRepository = new PurchaseOrderEntryRespository();

        }

        //metodos
                public void agreagar() {

                    double cantidadRecibida = intermediaEscaneoRepository.obtenerCantidadRecibida(numeroOrdenDeCompra, codigoProducto);
                    double cantidadTotalProxima = cantidadRecibida + cantidad; 

                    double cantidadOrdenada = sapEntryRepository.ObtenerCantidadOrdenada(numeroOrdenDeCompra, codigoProducto);



                    if (cantidadOrdenada < cantidadTotalProxima)
                     {
                                // devolver error de que cantidad a ingresar excede cantidad ordenada
                     }
                      else
                      {
                             cbr_ComprasSAP_Escaneo escaneo = new cbr_ComprasSAP_Escaneo();

                                escaneo.baseEntry = numeroOrdenDeCompra;
                                escaneo.cantidad = cantidad;
                                escaneo.entradaMercanciaDocEntry = numeroEntradaDeMercancía;
                                escaneo.itemCode = codigoProducto;
                                escaneo.fecha = fecha;
                                escaneo.userID = usuario;

                            intermediaEscaneoRepository.GuardarEscaneo(escaneo);

                       }



                     
                
                }

    }
}
