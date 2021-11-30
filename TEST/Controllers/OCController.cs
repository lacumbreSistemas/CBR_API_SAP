
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
        PurchaseOrderRepository po = new PurchaseOrderRepository();


       

        [HttpGet("OCAbiertas")]
        public IActionResult GetOpen([FromHeader] string WhsCode)
        {

            List<PurchaseOrderModel> OCs = po.getPurchaseOrderAbiertasHeaders(WhsCode);


            return Ok(OCs);
        }


        [HttpPost("Escaneo/{usuario}")]
        public IActionResult Post([FromBody] PurchaseOrderEntryModel Entry, string usuario)
        {
            PurchaseOrderEntryModel aa = new PurchaseOrderEntryModel(Entry);
            po.addNewEntry(aa, usuario);


            return Ok("Bien");
        }


    }
}
