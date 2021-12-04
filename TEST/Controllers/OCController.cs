
using Domain.Models;
using Domain.Repositories;
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

       private EscaneoRepository Escaneos = new EscaneoRepository();
       //private PurchaseOrderRepository po = new PurchaseOrderRepository();
        private PurchaseOrderRepository po;
        private readonly ILogger<OCController> _logger;

        public OCController(ILogger<OCController> logger) {
            _logger = logger;
        }


        [HttpGet("OCAbiertas")]
        public IActionResult GetAbiertas([FromHeader] string WhsCode)
        {

            List<PurchaseOrderModel> OCs = po.getPurchaseOrderAbiertasHeaders(WhsCode);


            return Ok(OCs);
        }


        [HttpPost("Escaneo/{usuario}")]
        public IActionResult Post([FromBody] EscaneoModel escaneo)
        {

            Escaneos.Agregar(escaneo);


            return Ok("Bien");
        }

        [HttpGet("Resumen/{numeroDeOrdenDeCompra}")]
        public IActionResult GetResumen(int numeroDeOrdenDeCompra)
        {
            PurchaseOrderModel OC = po.getPurchaseOrder(numeroDeOrdenDeCompra);
            return Ok(OC);
        }



    }
}
