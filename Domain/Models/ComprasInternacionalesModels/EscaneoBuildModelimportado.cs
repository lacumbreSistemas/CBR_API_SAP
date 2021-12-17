using Intermedia_;
using Intermedia_.Repositories;
using SAP.Repositories;
using SAP.Repositories.ComprasInternacionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComprasInternacionalesModels
{
    public class EscaneoBuildModelimportado:EscaneoMasterModel 
    {

        private cbr_ComprasSAP_Escaneo_Repository intermediaEscaneoRepository { get; set; }
        private FacturaReservaEntryRepository sapEntryRepository { get; set; }


        public EscaneoBuildModelimportado()
        {

        }



        public EscaneoBuildModelimportado(EscaneoBuildModelimportado newEscaneo)
        {

            numeroOrdenDeCompra = newEscaneo.numeroOrdenDeCompra;
            codigoProducto = newEscaneo.codigoProducto;
            usuario = newEscaneo.usuario;
            cantidad = newEscaneo.cantidad;
            fecha = DateTime.Now;
            numeroEntradaDeMercancía = newEscaneo.numeroEntradaDeMercancía;

            intermediaEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();
            //sapEntryRepository = new PurchaseOrderEntryRespository();

        }



        public EscaneoBuildModelimportado agreagar()
        {
            sapEntryRepository = new FacturaReservaEntryRepository();

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
                escaneo.baseLine = sapEntryRepository.obtenerLineNum(numeroOrdenDeCompra, codigoProducto);


                intermediaEscaneoRepository.GuardarEscaneo(escaneo);

            }


            return this;

        }

    }
}
