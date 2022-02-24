using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseController : Controller
    {
        Response _response = new Response();
     

      public  ResponseController() {
       
        }

        [HttpGet("ResponseGet/{h}")]
        public IActionResult ResponseGet(string h)
        {
            _response.status = 1;
            _response.mensaje = "exitoso";
            _response.data = h;


            return Ok(_response);
        }

        [HttpGet("ResponsePost")]
        public IActionResult ResponsePost()
        {
          
            return Ok();
        }
    }
}
 