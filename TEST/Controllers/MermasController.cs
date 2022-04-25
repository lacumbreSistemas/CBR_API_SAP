using Domain.Models.Mermas;
using Domain.Repositories.Mermas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [Route("api/[controller]")]
    public class MermasController : Controller
    {

        public Response _Response { get; set; }
        private EscaneoMermasEntryRepo EscaneoEntrysRepo { get; set; }
        private MermasRepo mermasRepo { get; set; }

        public MermasController() {
            _Response = new Response();
            EscaneoEntrysRepo = new EscaneoMermasEntryRepo();
            mermasRepo = new MermasRepo();


        }

        [HttpGet]
        public IActionResult mermas([FromHeader]string WhsCode)
        {

            _Response.mensaje = "Lista de documentos intermedios de mermas para tienda " + WhsCode;
            _Response.data = mermasRepo.obtenerListaMermasIntermediaAbiertas(WhsCode); 



            return Ok(_Response);
        }

        [HttpGet("Resumen/{numero}")]

        public IActionResult resumenMermas(int numero) {
            _Response.mensaje = "Resumen de documento intermedio de devolucion número" + numero;
            _Response.data = mermasRepo.resumenDocumentoIntermedioMerma(numero);


            return Ok(_Response); 

        }

        [HttpGet("Historial/{numero}/{itemCode}")]
        public IActionResult historialEscaneoEntry(int numero, string itemCode)
        {

            _Response.mensaje = "Historial de escaneos del item " + itemCode + "en la solicitud de devolucion " + numero;
            _Response.data = EscaneoEntrysRepo.historielEntries(numero, itemCode);

            return Ok(_Response); 

        }


        [HttpPost("GenerarMermaSAP/{numero}")]
        public IActionResult generarSolicitudDevolucionSAP(int numero)
        {
            var mermaSAP = mermasRepo.generarMermaSAP(numero);

            _Response.mensaje = "Documento preliminar de Merma " + mermaSAP.DocEntry + " creado exitosamente en SAP";
            _Response.data = mermaSAP;
            return Ok(_Response);
        }



        [HttpPost]
        public IActionResult guardarDocumentoIntermedioMerma([FromBody] MermasModelBuild mermasEntryModelBuild, [FromHeader] string WhsCode) {
            var guadar = mermasRepo.crearDocumentoIntermedioMerma(mermasEntryModelBuild, WhsCode);
            _Response.mensaje = "Documento intermedio de merma "+ guadar.numero + " creado con éxito ";
            _Response.data = guadar;
            return Ok(_Response);
        
        }


        [HttpPost("Escaneo")]

        public IActionResult guardarEntrieMerma([FromBody] MermasEntryModelBuild mermasEntryModelBuild) {

            _Response.mensaje = "Escaneo guardado con éxito";
            _Response.data = EscaneoEntrysRepo.crearMermaEntry (mermasEntryModelBuild); 


            return Ok(_Response);
        }


        [HttpDelete("AnularEscaneo")]

        public IActionResult anularEscaneo([FromBody] MermasEntryModelConsulta mermasEntryModelConsulta) {


            _Response.mensaje = "Escaneo anulado";
            _Response.data = EscaneoEntrysRepo.anularEscane(mermasEntryModelConsulta);
            return Ok(_Response); 
        
        }


        [HttpDelete("AnularItem")]
        public IActionResult anularEscaneosItem([FromBody] MermasEntryResumenActualizar mermasEntryResumenActualizar) {

            mermasRepo.anularEscaneosItemCodeNumero(mermasEntryResumenActualizar);

            _Response.mensaje = "Escaneos del item " + mermasEntryResumenActualizar.descripcionProducto + " anulado con éxito";
            return Ok(_Response);


        }


        [HttpGet("obtenerRemarks")]
        public IActionResult obtenerRemarks()
        {

            var remarks = mermasRepo.obtenerRemarks();
            _Response.mensaje = "Lista de remarks";
            _Response.data = remarks;


            return Ok(_Response);

        }


        [HttpPost("AnularSolicitud/{numero}")]

        public IActionResult AnularMerma(int numero) {

            var cancelar = mermasRepo.cancelarMerma(numero);
            _Response.mensaje = cancelar;


            return Ok(_Response);

        }


    }
}
