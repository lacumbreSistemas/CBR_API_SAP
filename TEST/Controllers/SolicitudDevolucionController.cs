using Domain.Models.SolicitudDevolucionModels;
using Domain.Repositories.SolicitudDevolucionRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{

    [Route("api/[controller]")]
    public class SolicitudDevolucionController : Controller
    {
        public Response _Response { get; set; } 
        private SolicitudDevolucionRepo SolicitudDevolucionRepo { get; set; }

        public SolicitudDevolucionController() {
            _Response = new Response();

            SolicitudDevolucionRepo = new SolicitudDevolucionRepo();
        }


        [HttpGet("{Whscode}")]
        public IActionResult solititudDevolucion(string Whscode)
        {
      

            _Response.mensaje = "Lista de solicitudes de devolucion para tienda "+Whscode;
            _Response.data = SolicitudDevolucionRepo.obtenerListaSolicitudesDevolucionSinDocentry(Whscode); ;


            return Ok(_Response);
        }


        [HttpPost]
        public IActionResult guardarSolicitudDevolusion([FromBody]SolicitudDevolucionModelBuild solicitudTraslado)
        {
            var guardarSolicitudDevolucion = SolicitudDevolucionRepo.crearSolicitudDevolucionIntermedia(solicitudTraslado);

            _Response.mensaje = "Solicitud de traslado " + guardarSolicitudDevolucion.Numero+" guardada con éxito";
            _Response.data = guardarSolicitudDevolucion; 


            return Ok(_Response);
        }


        [HttpPost("Escaneo")]
        public IActionResult guardarSolicitudDevolusionEntry([FromBody] SolicitudDevolucionEntryModelBuild solicitudTraslado)
        {
           

            _Response.mensaje = "Escaneo guardada con éxito";
            _Response.data = SolicitudDevolucionRepo.crearSolicitudDevolusionEntry(solicitudTraslado);


            return Ok(_Response);
        }


        [HttpGet("Resumen/{numero}")]
        public IActionResult resumenSolicitudDevolucion(int numero)
        {


            _Response.mensaje = "Resumen de solicitud de devolucion número "+numero;
            _Response.data = SolicitudDevolucionRepo.resumenSolicitudDevolucion(numero);


            return Ok(_Response);
        }

    }
}
