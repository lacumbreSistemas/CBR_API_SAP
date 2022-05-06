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
        private ProduccionRepo produccionRepo { get; set; }
        public ProduccionController() {
            produccionRepo = new ProduccionRepo();
            _Response = new Response();
        }


        #region  get



        #endregion


        #region  post
        public IActionResult crearDocumentoIntermedio([FromBody] ProduccionModelBuild  documentoIntermedioProduccion, [FromHeader] string WhsCode) {

            var guardarDocumentoIntermedioProduccion = produccionRepo.crearDocumentoProduccionIntermedia(documentoIntermedioProduccion, WhsCode);



            _Response.mensaje = "Solicitud de traslado " + guardarDocumentoIntermedioProduccion.numero + " guardada con éxito";
            _Response.data = guardarDocumentoIntermedioProduccion;


            return Ok(); 
        }



        #endregion
    }
}
