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
        private EscaneoEntrysRepo _EscaneoEntrysRepo { get; set;} 
        private SolicitudDevolucionRepo SolicitudDevolucionRepo { get; set; }

        public SolicitudDevolucionController() {
            _Response = new Response();
            _EscaneoEntrysRepo = new EscaneoEntrysRepo();
            SolicitudDevolucionRepo = new SolicitudDevolucionRepo();
        }

        //funciones get


        [HttpGet]
        public IActionResult solititudDevolucion([FromHeader]string Whscode)
        {
      

            _Response.mensaje = "Lista de solicitudes de devolucion para tienda "+ WhsCode;
            _Response.data = SolicitudDevolucionRepo.obtenerListaSolicitudesDevolucionSinDocentry(WhsCode); ;


            return Ok(_Response);
        }


       

        [HttpGet("Resumen/{numero}")]
        public IActionResult resumenSolicitudDevolucion(int numero)
        {


            _Response.mensaje = "Resumen de solicitud de devolucion número "+numero;
            _Response.data = SolicitudDevolucionRepo.resumenSolicitudDevolucion(numero);


            return Ok(_Response);
        }


        [HttpGet("Historial/{numero}/{itemCode}")]
        public IActionResult historialEscaneosEntry(int numero,string itemCode)
        {


            _Response.mensaje = "Historial de escaneos del item " + itemCode+" en la solicitud de devolucion "+numero;
            _Response.data = _EscaneoEntrysRepo.historialEscaneosEntries(numero,itemCode);


            return Ok(_Response);
        }


        //funciones Post


        [HttpPost]
        public IActionResult guardarSolicitudDevolusion([FromBody] SolicitudDevolucionModelBuild solicitudTraslado, [FromHeader] string WhsCode)
        {
            var guardarSolicitudDevolucion = SolicitudDevolucionRepo.crearSolicitudDevolucionIntermedia(solicitudTraslado,WhsCode);

            var guardarSolicitudDevolucion = SolicitudDevolucionRepo.crearSolicitudDevolucionIntermedia(solicitudTraslado, Whscode);

            _Response.mensaje = "Solicitud de traslado " + guardarSolicitudDevolucion.numeroDevolucion + " guardada con éxito";
            _Response.data = guardarSolicitudDevolucion;


            return Ok(_Response);
        }


        [HttpPost("Escaneo")]
        public IActionResult guardarSolicitudDevolusionEntry([FromBody] SolicitudDevolucionEntryModelBuild solicitudTraslado)
        {

            _Response.mensaje = "Escaneo guardada con éxito";
            _Response.data = _EscaneoEntrysRepo.crearSolicitudDevolusionEntry(solicitudTraslado);

            return Ok(_Response);
        }


        //delete 

        [HttpDelete("AnularEscaneo")]
        public IActionResult anularEscaneo([FromBody] SolicitudDevolucionEntryModelConsulta _solicitudTrasladoEntry)
        {


            _Response.mensaje = "Escaneo anulado "; 
             _Response.data = _EscaneoEntrysRepo.anularEscaneo(_solicitudTrasladoEntry);

            return Ok(_Response);
        }


        [HttpDelete("AnularItem")]
        public IActionResult anularEscaneosItem([FromBody]SolicitudDevolucionEntryResumenActualizar solicitudDevolucionEntryResumenActualizar) {


            SolicitudDevolucionRepo.anularEscaneosItemCodeNumero(solicitudDevolucionEntryResumenActualizar);
            _Response.status = 1;
            _Response.mensaje = "Escaneos del item "+solicitudDevolucionEntryResumenActualizar.DescripcionProducto+" anulados con éxito";   
            return Ok(_Response);
        }



        [HttpPost("GenerarSolicitudDevolucionSAP")]
        public IActionResult generarSolicitudDevolucionSAP([FromHeader] int numero)
        {
            var solicitudDevolucionSAP = SolicitudDevolucionRepo.generarSolicitudDevolucionSAP(numero);

            _Response.mensaje = "Documento de solicitud de devolucion" + solicitudDevolucionSAP.DocEntry + "creado exitosamente en SAP";
            _Response.data = solicitudDevolucionSAP;
            return Ok(_Response);
        }


    }
}
