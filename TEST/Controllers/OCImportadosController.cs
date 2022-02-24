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

        private EscaneoImportadosRepository escaneoRespository { get; set; }
        Response response { get; set; }
      public   OCImportadosController() {
            response =  new Response();
            fe = new FacturasReservaRepository();
            escaneoRespository = new EscaneoImportadosRepository();
            escaneoRepo = new EscaneoRepository();
        }


       

      



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
            response.mensaje = "Escaneo de Item: " + guardarEscaneo.codigoProducto + " agregado correctamente";
            response.data = guardarEscaneo;

            return Ok(response);
        }


        [HttpPost("{DocEntry}")]
        public IActionResult Guardar(int DocEntry)
        {

            var EM = fe.guardarEntradaMercancia(DocEntry);
            response.status = 1;
            response.mensaje = "Se ha generado entrada de mercancía numero " + EM.ToString(); 
            response.data = EM;


            return Ok(response);
        }


           [HttpDelete("Escaneo/{escaneoId}")]
        public IActionResult anularEscaneo(int escaneoId)
        {
          
            response.status = 1;
            response.mensaje = "Escaneo eliminado";
            response.data = escaneoRepo.anularEscaneo(escaneoId);


            return Ok(response);
        }

    }
}
