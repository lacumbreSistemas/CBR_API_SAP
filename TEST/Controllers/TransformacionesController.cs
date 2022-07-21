using Domain.Models.Produccion;
using Domain.Repositories.Produccion;
using Domain.Repositories.Transformaciones;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [Route("api/[controller]")]
    public class TransformacionesController : Controller
    {
        public Response _Response { get; set; }
        private ListaMaterialesTransformacionRepo listaMaterialesRepo { get; set; }
        public EscaneoTransformacionRepo escaneoTransformacionRepo { get; set; }
        private TransformacionesRepo transformacionRepo { get; set; }


        public TransformacionesController() {
            listaMaterialesRepo = new ListaMaterialesTransformacionRepo();
            escaneoTransformacionRepo = new EscaneoTransformacionRepo();
            transformacionRepo = new TransformacionesRepo();
            _Response = new Response();

        }


        #region funciones GEt

        [HttpGet]
        public IActionResult obtenerDocumentosIntermediosAbiertos([FromHeader] string WhsCode)
        {

            _Response.mensaje = "Lista de documentos de producción ";
            _Response.data = transformacionRepo.obtenerListaDocumentosIntermediosTransformacion(WhsCode);


            return Ok(_Response);
        }


        [HttpGet]
        [HttpGet("Empaques")]
        public IActionResult obtenerListaEmpaques()
        {

            _Response.mensaje = "Lista de empaques";
            _Response.data = transformacionRepo.obtenerListaEmpaques();


            return Ok(_Response);
        }

        [HttpGet("Resumen/{numero}")]
        public IActionResult resumenDocumentosTransformacion(int numero)
        {


            _Response.mensaje = "Resumen de documento intermedio de transformación" + numero;
            _Response.data = transformacionRepo.resumenDocumentoTransformacion(numero);


            return Ok(_Response);
        }


        [HttpGet("Historial/{numero}/{itemCode}")]
        public IActionResult historialEscaneosEntry(int numero, string itemCode)
        {


            _Response.mensaje = "Historial de escaneos del item " + itemCode + " en la solicitud de devolucion " + numero;
            _Response.data = escaneoTransformacionRepo.historialEntries(numero, itemCode);


            return Ok(_Response);
        }

        [HttpGet("ListaMateriales")]
        public IActionResult listaMateriales()
        {
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

        #region funciones post
        [HttpPost]
        public IActionResult crearDocumentoIntermedio([FromBody] ProcesosModelBuild documentoIntermedioProduccion, [FromHeader] string WhsCode, [FromHeader] bool empaque)
        {

            var guardarDocumentoIntermedioProduccion = transformacionRepo.crearDocumentoProduccionIntermedia(documentoIntermedioProduccion, WhsCode, empaque);



            _Response.mensaje = "Documento intermedio de transformación " + guardarDocumentoIntermedioProduccion.numero + " guardado con éxito";
            _Response.data = guardarDocumentoIntermedioProduccion;


            return Ok(_Response);
        }


        [HttpPost("Escaneo")]
        public IActionResult guardarDocumentoProduccionEntry([FromBody] ProcesosEntryModelBuild produccionEntry)
        {

            _Response.mensaje = "Escaneo guardada con éxito";
            _Response.data = escaneoTransformacionRepo.crearEntryProduccion(produccionEntry);

            return Ok(_Response);
        }


        [HttpPost("AnularDocumentoIntermedio/{numero}")]
        public IActionResult AnularDocumentoIntermedio(int numero)
        {

            var cancelar = transformacionRepo.cancelarDocumento(numero);
            _Response.mensaje = cancelar;
            _Response.data = null;


            return Ok(_Response);
        }


        #endregion

        #region funciones delete 


        [HttpDelete("AnularEscaneo")]
        public IActionResult anularEscaneo([FromBody] ProcesosEntryModelConsulta produccionEntryModelConsulta)
        {


            _Response.mensaje = "Escaneo anulado";
            _Response.data = escaneoTransformacionRepo.anularEscaneo(produccionEntryModelConsulta);

            return Ok(_Response);

        }


        [HttpDelete("AnularItem")]
        public IActionResult anularEscaneosItem([FromBody] ProcesosEntryResumenActualizar produccionEntryResumenActualizar)
        {


            transformacionRepo.anularEscaneosItemCodeNumero(produccionEntryResumenActualizar);
            _Response.status = 1;
            _Response.mensaje = "Escaneos del item " + produccionEntryResumenActualizar.descripcionProducto + " anulados con éxito";
            return Ok(_Response);
        }
        #endregion
    }
}
