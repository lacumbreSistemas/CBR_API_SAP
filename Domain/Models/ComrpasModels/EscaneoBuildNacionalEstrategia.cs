using Domain.Interfaces;
using Intermedia_;
using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComrpasModels
{
    public class EscaneoBuildNacionalEstrategia : IEscaneoBuildEstrategia
    {

        private PurchaseOrderEntryRespository sapEntryRepository { get; set; }
        private cbr_ComprasSAP_Escaneo_Repository intermediaEscaneoRepository { get; set; }
        public EscaneoBuildNacionalEstrategia() {
            sapEntryRepository = new PurchaseOrderEntryRespository();
            intermediaEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();
        }

        public double ObtenerCantidadOrdenada(int? docEntry, string itemCode)
        {
            return sapEntryRepository.ObtenerCantidadOrdenada(docEntry, itemCode);
          
        }

        public int obtenerLineNum(int? docEntry, string itemCode)
        {

            return sapEntryRepository.obtenerLineNum(docEntry, itemCode);
            
        }

        public void GuardarEscaneo(EscaneoBuildModel _escaneo)
        {

            if (_escaneo.matriculado)
            {
                double cantidadEscaneada = intermediaEscaneoRepository.obtenerCantidadEscaneada(_escaneo.ordenCompraDocEntry, _escaneo.codigoProducto);
                double? cantidadTotalProxima = cantidadEscaneada + _escaneo.cantidad;

                double cantidadOrdenada = this.ObtenerCantidadOrdenada(_escaneo.ordenCompraDocEntry, _escaneo.codigoProducto);

                if (cantidadOrdenada < cantidadTotalProxima)
                {
                    throw new Exception("Cantidad ingresada excede la cantidad pedida en la orden de compra");
                }
                else
                {

                    cbr_ComprasSAP_Escaneo escaneo = new cbr_ComprasSAP_Escaneo();

                    escaneo.baseEntry = _escaneo.ordenCompraDocEntry;
                    escaneo.cantidad = _escaneo.cantidad;
                    //escaneo.entradaMercanciaDocEntry = numeroEntradaDeMercancía;
                    escaneo.itemCode = _escaneo.codigoProducto;
                    escaneo.fecha = _escaneo.fecha;
                    escaneo.nombreUsuario = _escaneo.usuario;
                    escaneo.baseLine = obtenerLineNum(_escaneo.ordenCompraDocEntry, _escaneo.codigoProducto);
                    escaneo.matriculado = _escaneo.matriculado;

                    intermediaEscaneoRepository.GuardarEscaneoInternacional(escaneo);
                }

            }
            else {

                throw new Exception("Producto no matriculado");
            }
           
                

            //return this;

        }
    }
}
