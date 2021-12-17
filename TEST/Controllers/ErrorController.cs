using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.AspNetCore.Diagnostics;

namespace TEST.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error")]
        //[HttpGet]
        public IActionResult Error()
        {
            Response response = new Response();

            var Exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            response.status = 0;
            response.mensaje = Exception.Error.Message;
            response.data = null;


            return Ok(response);
        }
    }
}
