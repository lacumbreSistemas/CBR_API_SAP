using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Repositories;
using Intermedia_;
using Domain.Interfaces;

namespace Domain.Models
{
   public class EscaneoBuildModel: EscaneoMasterModel
    {

       
    

        //privaate

        private cbr_ComprasSAP_Escaneo_Repository intermediaEscaneoRepository { get; set; }
        private PurchaseOrderEntryRespository sapEntryRepository { get; set; }

        //constructores
        public EscaneoBuildModel( ) { 
        
        }

       
       public EscaneoBuildModel(EscaneoBuildModel newEscaneo) {

            numeroOrdenDeCompra = newEscaneo.numeroOrdenDeCompra;
            codigoProducto = newEscaneo.codigoProducto;
            usuario = newEscaneo.usuario;
            cantidad = newEscaneo.cantidad;
            fecha = DateTime.Now;
            numeroEntradaDeMercancía = newEscaneo.numeroEntradaDeMercancía;

            intermediaEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();
            //sapEntryRepository = new PurchaseOrderEntryRespository();

        }

        //metodos
                public EscaneoBuildModel agreagar() {
                   sapEntryRepository = new PurchaseOrderEntryRespository();

                            double cantidadEscaneada = intermediaEscaneoRepository.obtenerCantidadRecibida(numeroOrdenDeCompra, codigoProducto);
                            double? cantidadTotalProxima = cantidadEscaneada + cantidad;
           


                            double cantidadOrdenada = sapEntryRepository.ObtenerCantidadOrdenada(numeroOrdenDeCompra, codigoProducto);
            
                             if (cantidadOrdenada < cantidadTotalProxima)
                             {
                                    throw new Exception("Cantidad ingresada excede la cantidad pedida en la orden de compra");
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
                                        escaneo.baseLine = sapEntryRepository.obtenerLineNum(numeroOrdenDeCompra,codigoProducto);


                                    intermediaEscaneoRepository.GuardarEscaneo(escaneo);

                              }



                    return this;
                
                }

    }
}
