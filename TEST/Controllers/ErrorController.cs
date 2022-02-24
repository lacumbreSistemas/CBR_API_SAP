using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.AspNetCore.Diagnostics;
using Domain.Models;

namespace TEST.Controllers
{
    public class ErrorController : Controller
    {
        ErrorModel ErrorLog { get; set; }


        public ErrorController() {
            ErrorLog = new ErrorModel();
        }


        [Route("Error")]
        //[HttpGet]
        public IActionResult Error()
        {
            Response response = new Response();

            //var Exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

          

            var Exception =  HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ErrorLog.mensaje = Exception.Error.Message;
            ErrorLog.ruta = Exception.Path;
            ErrorLog.detalle = Exception.Error.StackTrace;

             
            response.status = 0;
            response.mensaje = Exception.Error.Message+", número de caso "+ ErrorLog.guardar(); 
            response.data = null;


            return Ok(response);
        }
    }
}
