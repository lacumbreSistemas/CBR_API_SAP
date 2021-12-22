using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.ComprasInternacionales;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OCImportadosController : ControllerBase
    {


        //private PurchaseOrderRepository po;
        private FacturasReservaRepository fe { get; set; }
        EscaneoRepository escaneoRepo { get; set; }
        Response response ;
      public   OCImportadosController() {
            response =  new Response();
            fe = new FacturasReservaRepository();
            escaneoRespository = new EscaneoImportadosRepository();
            escaneoRepo = new EscaneoRepository();
        }


        private EscaneoImportadosRepository escaneoRespository;

      



        [HttpGet("OCAbiertas")]
        public IActionResult FRAbiertas([FromHeader] string WhsCode)
        {
            response.status = 1;
            response.mensaje = "Ordenes de compra abiertas para almacen " + WhsCode;
            response.data = fe.getPurchaseOrderAbiertasHeaders(WhsCode);

           
     
            return Ok(response);
        }

        [HttpGet("Historial/{ordenDeCompraDocEntry}/{itemCode}")]
        public IActionResult Historial(int ordenDeCompraDocEntry, string itemCode)
        {
            response.status = 1;
            response.mensaje = "Historial de escaneo para el item " + itemCode + " en la orden de compra " + ordenDeCompraDocEntry;
            response.data = escaneoRepo.obtenerHistorial(ordenDeCompraDocEntry, itemCode);
            return Ok(response);

        }


        [HttpGet("Resumen/{numeroDeOrdenDeCompra}")]
        public IActionResult GetResumen(int numeroDeOrdenDeCompra)
        {
            response.status = 1;
            response.mensaje = "Resumen de orden de compra número "+numeroDeOrdenDeCompra;
            response.data = fe.getFacturaReserva(numeroDeOrdenDeCompra, true);


            return Ok(response);
        }


        [HttpPost("Escaneo")]
        public IActionResult Post([FromBody] EscaneoBuildModel escaneo)
        {

            var guardarEscaneo = escaneoRespository.Agregar(escaneo);


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
            response.data = fe.guardarEntradaMercancia(DocEntry);


            return Ok(response);
        }

           [HttpDelete("Escaneo/{escaneoId}")]
        public IActionResult anularEscaneo(int escaneoId)
        {
          
            response.status = 1;
            response.mensaje = "exitoso";
            response.data = escaneoRepo.anularEscaneo(escaneoId);


            return Ok(response);
        }

    }
}
