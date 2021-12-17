
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

        private EscaneoRepository Escaneos;
 
       private PurchaseOrderRepository po;
        private FacturasReservaRepository fe;
  
        Response response = new Response();
   

        public OCController() {
            Escaneos = new EscaneoRepository();
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



        [HttpGet("FRAbiertas")]
        public IActionResult FRAbiertas([FromHeader] string WhsCode)
        {
            //response.status = 1;
            //response.mensaje = "Ordenes abiertas para almacen " + WhsCode;
            //response.data = po.getPurchaseOrderAbiertasHeaders(WhsCode);

            //List<PurchaseOrderModel> OCs = po.getPurchaseOrderAbiertasHeaders(WhsCode);
            //return Ok(OCs);
            return Ok();
        }



        [HttpGet("Resumen/{numeroDeOrdenDeCompra}")]
        public IActionResult GetResumen(int numeroDeOrdenDeCompra)
        {
            PurchaseOrderModel OC = po.getPurchaseOrder(numeroDeOrdenDeCompra,true);
            return Ok(OC);
        }


       



        [HttpPost("Escaneo/{usuario}")]
        public IActionResult Post([FromBody] EscaneoBuildModel escaneo)
        {

            var guardarEscaneo = Escaneos.Agregar(escaneo);


            response.status = 1;
            response.mensaje = "Escaneo del item "+ guardarEscaneo.codigoProducto+ "para la orden de compra "+guardarEscaneo.numeroOrdenDeCompra;
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


        [HttpPost("{DocEntry}")]
        public IActionResult GuardarImportados(int DocEntry)
        {
            var escaneo =
            response.status = 1;
            response.mensaje = "exitoso";
            response.data = fe.guardarEntradaMercancia(DocEntry);


            return Ok(response);
        }


    }
}
