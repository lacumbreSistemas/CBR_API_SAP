
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.ComprasInternacionales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAP.Models;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OCController : ControllerBase
    {

        private EscaneoRepository escaneiRepository;

        private PurchaseOrderRepository po;
        private FacturasReservaRepository fe;

        Response response = new Response();


        public OCController() {
            escaneiRepository = new Domain.Repositories.EscaneoRepository();
            po = new PurchaseOrderRepository();
            fe = new FacturasReservaRepository();
        }


        [HttpGet("OCAbiertas")]
        public IActionResult GetAbiertas([FromHeader] string WhsCode)
        {

            response.status = 1;
            response.mensaje = "Ordenes abiertas para almacen " + WhsCode;
            response.data = po.getPurchaseOrderAbiertasHeaders(WhsCode);


            return Ok(response);
        }



        [HttpGet("Resumen/{numeroDeOrdenDeCompra}")]
        public IActionResult GetResumen(int numeroDeOrdenDeCompra)
        {

            response.status = 1;
            response.mensaje = "Resumen de la ordend e compra " + numeroDeOrdenDeCompra;
            response.data = po.getPurchaseOrder(numeroDeOrdenDeCompra, true);


            return Ok(response);
        }


        [HttpGet("Historial/{numeroDeOrdenDeCompra}/{itemCode}")]
        public IActionResult Historial(int numeroDeOrdenDeCompra, string itemCode)
        {
            response.status = 1;
            response.mensaje = "Historial de escaneo para el item " + itemCode + "en la orden de compra " + numeroDeOrdenDeCompra;
            response.data = escaneiRepository.obtenerHistorial(numeroDeOrdenDeCompra, itemCode);
            return Ok(response);

        }



        [HttpPost("Escaneo")]
        public IActionResult Post([FromBody] EscaneoBuildModel escaneo)
        {

            var guardarEscaneo = escaneiRepository.Agregar(escaneo);


            response.status = 1;
            response.mensaje = "Escaneo del item " + guardarEscaneo.codigoProducto + "para la orden de compra " + guardarEscaneo.ordenCompraDocEntry;
            response.data = guardarEscaneo;

            return Ok(response);
        }




        [HttpPost("{DocEntry}")]
        public IActionResult Guardar(int DocEntry)
        {
            var escaneo =
            response.status = 1;
            response.mensaje = "exitoso";
            response.data = po.guardarEntradaMercancia(DocEntry);


            return Ok(response);
        }


        [HttpDelete("Escaneo/{escaneoId}")]
        public IActionResult anularEscaneo(int escaneoId)
        {
          
            response.status = 1;
            response.mensaje = "exitoso";
            response.data = escaneiRepository.anularEscaneo(escaneoId);


            return Ok(response);
        }



    }
}
