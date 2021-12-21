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
        private FacturasReservaRepository fe;

        Response response ;
      public   OCImportadosController() {
            response =  new Response();
            fe = new FacturasReservaRepository();
            Escaneos = new EscaneoImportadosRepository();
        }

        private EscaneoImportadosRepository Escaneos;

      



        [HttpGet("OCAbiertas")]
        public IActionResult FRAbiertas([FromHeader] string WhsCode)
        {
            response.status = 1;
            response.mensaje = "Ordenes de compra abiertas para almacen " + WhsCode;
            response.data = fe.getPurchaseOrderAbiertasHeaders(WhsCode);

           
     
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


        [HttpPost("Escaneo/{usuario}")]
        public IActionResult Post([FromBody] EscaneoBuildModel escaneo)
        {

            var guardarEscaneo = Escaneos.Agregar(escaneo);


            response.status = 1;
            response.mensaje = "Escaneo del item " + guardarEscaneo.codigoProducto + "para la orden de compra " + guardarEscaneo.numeroOrdenDeCompra;
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



    }
}
