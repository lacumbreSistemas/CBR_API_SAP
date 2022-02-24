using Domain.Models.ComrpasModels;
using Domain.Repositories;
using Domain.Repositories.ComprasContenedorInternacionalLista;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContenedorComprasImportadosListaController : ControllerBase
    {

        ListaEscaneosImportadosRepository EscaneosRepo { get; set; }
        ContenedorImportadosListaRepository contenedorImportadosListaRepository { get; set; }
        Response response { get; set; }
        public ContenedorComprasImportadosListaController() {
            contenedorImportadosListaRepository = new ContenedorImportadosListaRepository();
            EscaneosRepo = new ListaEscaneosImportadosRepository();
            response = new Response();
        }

        //get

        [HttpGet("Abiertos")]

        public IActionResult ObtenerAbiertos([FromHeader] string WhsCode) {
           

            response.status = 1;
            response.mensaje = "Contenedores abiertos pendientes de recibir";
            response.data = contenedorImportadosListaRepository.obtenercontenedoresAbiertos(WhsCode);


            return Ok(response);
        }

        [HttpGet("Resumen/{numeroContenedor}")]
        public IActionResult Resumen(string numeroContenedor) {


            response.status = 1;
            response.mensaje = "Resumen de contenedor "+ numeroContenedor;
            response.data = contenedorImportadosListaRepository.obtenerContenedor(numeroContenedor, true);

            return Ok(response);

        }


        [HttpGet("Historial/{itemCode}/{numeroContenedor}")]
        public IActionResult Historial(string itemCode, string numeroContenedor)
        {

            response.status = 1;
            response.mensaje = "Historial de escaneos para contenedor " + numeroContenedor + "  item " + itemCode;
            response.data = EscaneosRepo.getHistorial(itemCode, numeroContenedor);


            return Ok(response);
        }


        //Post

        [HttpPost("Escaneo")]
        public IActionResult Escaneo([FromBody] ListaEscaneosImportados escaneo) {


            var guardarEscaneo = EscaneosRepo.Agregar(escaneo);

            response.status = 1;
            response.mensaje = "item "+escaneo.codigoProducto+" agregado correctamente";
            response.data = guardarEscaneo;

            return Ok(response);
        }

        //Delete

        [HttpDelete("Escaneo/{escaneoId}")]
        public IActionResult anularEscaneo(int escaneoId)
        {

            response.status = 1;
            response.mensaje = "Escaneo eliminado";
            response.data = EscaneosRepo.anularEscaneo(escaneoId);


            return Ok(response);
        }


    }
}
