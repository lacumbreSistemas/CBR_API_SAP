using Domain.Models.Produccion;
using Domain.Repositories.Produccion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [Route("api/[controller]")]
    public class ProduccionController : Controller
    {
        public Response _Response { get; set; }
        public EscaneoProduccionRepo escaneoProduccionRepo { get; set;}

        private ListaMaterialesRepo listaMaterialesRepo { get; set; }
        private ProduccionRepo produccionRepo { get; set; }
        public ProduccionController() {
            listaMaterialesRepo = new ListaMaterialesRepo();
            produccionRepo = new ProduccionRepo();
            escaneoProduccionRepo = new EscaneoProduccionRepo();
            _Response = new Response();
        }


        #region funciones get

        [HttpGet]
        public IActionResult obtenerDocumentosIntermediosAbiertos( [FromHeader] string WhsCode)
        {

            _Response.mensaje = "Lista de documentos de producción ";
            _Response.data = produccionRepo.obtenerListaDocumentosIntermediosProduccion(WhsCode);


            return Ok(_Response);
        }


        [HttpGet("Resumen/{numero}")]
        public IActionResult resumenSolicitudDevolucion(int numero)
        {


            _Response.mensaje = "Resumen de documento intermedio de producción" + numero;
            _Response.data = produccionRepo.resumenDocumentoProduccion(numero);


            return Ok(_Response);
        }

        [HttpGet("Historial/{numero}/{itemCode}")]
        public IActionResult historialEscaneosEntry(int numero, string itemCode)
        {


            _Response.mensaje = "Historial de escaneos del item " + itemCode + " en la solicitud de devolucion " + numero;
            _Response.data = escaneoProduccionRepo.historialEntries(numero, itemCode);


            return Ok(_Response);
        }


        [HttpGet("ListaMateriales")]
        public IActionResult listaMateriales() {
            _Response.data = listaMaterialesRepo.obtenerListaMateriales();
            _Response.mensaje = "Lista de materiales";



            return Ok(_Response);

        }

        [HttpGet("ListaMateriales/{code}")]
        public IActionResult listaMaterialesCode(string code)
        {
            _Response.data = listaMaterialesRepo.obtenerListaMaterialesCode(code);
            _Response.mensaje = "detalle de lista de materiales";



            return Ok(_Response);

        }

        #endregion


        #region funciones  post

        [HttpPost]
        public IActionResult crearDocumentoIntermedio([FromBody] ProduccionModelBuild  documentoIntermedioProduccion, [FromHeader] string WhsCode) {

            var guardarDocumentoIntermedioProduccion = produccionRepo.crearDocumentoProduccionIntermedia(documentoIntermedioProduccion, WhsCode);



            _Response.mensaje = "Documento intermedio de producción " + guardarDocumentoIntermedioProduccion.numero + " guardado con éxito";
            _Response.data = guardarDocumentoIntermedioProduccion;


            return Ok(_Response); 
        }


        [HttpPost("GenerarDocumentosSAP/{numero}")]
        public IActionResult generarSolicitudDevolucionSAP(int numero)
        {
            var mermaSAP = produccionRepo.generarSalidaSAP(numero);

            _Response.mensaje = "Creados documento de sálida " + mermaSAP.docEntrySalida + " Documento de entrada "+mermaSAP.docEntryEntrada;
            _Response.data = mermaSAP;
            return Ok(_Response);
        }


        [HttpPost("Escaneo")]
        public IActionResult guardarSolicitudDevolusionEntry([FromBody] ProduccionEntryModelBuild produccionEntry)
        {

            _Response.mensaje = "Escaneo guardada con éxito";
            _Response.data = escaneoProduccionRepo.crearEntryProduccion(produccionEntry);

            return Ok(_Response);
        }

       


        [HttpPost("AnularDocumentoIntermedio/{numero}")]
        public IActionResult AnularDocumentoIntermedio(int numero)
        {

            var cancelar = produccionRepo.cancelarDocumento(numero);
            _Response.mensaje = cancelar;
            _Response.data = null;


            return Ok(_Response);
        }


        #endregion


        #region delete


        [HttpDelete("AnularItem")]
        public IActionResult anularEscaneosItem([FromBody] ProduccionEntryResumenActualizar produccionEntryResumenActualizar)
        {


            produccionRepo.anularEscaneosItemCodeNumero(produccionEntryResumenActualizar);
            _Response.status = 1;
            _Response.mensaje = "Escaneos del item " + produccionEntryResumenActualizar.descripcionProducto + " anulados con éxito";
            return Ok(_Response);
        }

        [HttpDelete("AnularEscaneo")]
        public IActionResult anularEscaneo([FromBody] ProduccionEntryModelConsulta produccionEntryModelConsulta)
        {


            _Response.mensaje = "Escaneo anulado";
            _Response.data = escaneoProduccionRepo.anularEscaneo(produccionEntryModelConsulta);

            return Ok(_Response);
        
        }


        #endregion


    }
}
