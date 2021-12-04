using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {

       [HttpGet("Item/ItemCode")]
        public IActionResult Get(string ItemCode)
        {



            return Ok();
        }
    }
}
