
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

        private EscaneoRepository escaneiRepository { get; set; }
        private PurchaseOrderRepository po { get; set; }
        Response response { get; set; } 


        public OCController() {
            escaneiRepository = new Domain.Repositories.EscaneoRepository();
            po = new PurchaseOrderRepository();
            response = new Response();


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
            response.data = po.getPurchaseOrder(numeroDeOrdenDeCompra,true);


            return Ok(response);
        }


        [HttpGet("Historial/{ordenDeCompraDocEntry}/{itemCode}")]
        public IActionResult Historial(int ordenDeCompraDocEntry, string itemCode)
        {
            response.status = 1;
            response.mensaje = "Historial de escaneo para el item " + itemCode + " en la orden de compra " + ordenDeCompraDocEntry;
            response.data = escaneiRepository.obtenerHistorial(ordenDeCompraDocEntry, itemCode);
            return Ok(response);

        }



        [HttpPost("Escaneo")]
        public IActionResult Post([FromBody] EscaneoBuildModel escaneo)
        {

            var guardarEscaneo = escaneiRepository.Agregar(escaneo);


            response.status = 1;
            response.mensaje = "Escaneo de Item: " + guardarEscaneo.codigoProducto + " agregado correctamente";
            response.data = guardarEscaneo;

            return Ok(response);
        }




        [HttpPost("{DocEntry}")]
        public IActionResult Guardar(int DocEntry)
        {
            var EM = po.guardarEntradaMercancia(DocEntry);

            response.status = 1;
            response.mensaje = "Se ha generado entrada de mercancía numero "+ EM.ToString();
            response.data = EM;


            return Ok(response);
        }


        [HttpDelete("Escaneo/{escaneoId}")]
        public IActionResult anularEscaneo(int escaneoId)
        {
          
            response.status = 1;
            response.mensaje = "Escaneo eliminado";
            response.data = escaneiRepository.anularEscaneo(escaneoId);


            return Ok(response);
        }



    }
}
