using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenProduccionController : ControllerBase
    {

        OrdenProduccionRepo ordenProduccion = new OrdenProduccionRepo(); 
        [HttpGet]
        public IActionResult GenerarOrdenProduccion()
        {

            ordenProduccion.generarOrdenProduccion();

            return Ok();
        }
    }
}
