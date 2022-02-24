using Domain.Models;
using Domain.Repositories.ComprasInternacionales;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OCInternacionalContenedoresController : ControllerBase
    {
        Response resposne { get; set; }
        ContenedorRepository contenedoreRepository { get; set; }
  
        public OCInternacionalContenedoresController() {
        
            resposne = new Response();
            contenedoreRepository = new ContenedorRepository();

        }   


        [HttpGet("ContenedoresAbiertos")]
        public IActionResult contenedoresAbiertos([FromHeader]string WhsCode)
        {
            resposne.status = 1;
            resposne.mensaje = "Contenedores con ordenes de compra abiertas";
            resposne.data = contenedoreRepository.contenedoresAbiertos(WhsCode);

            return Ok(resposne);
        }


        [HttpPost("Escaneo/{numeroContenedor}")]
        public IActionResult escaneo([FromBody] EscaneoBuildModel escaneo,string numeroContenedor)
        {

            var escaneoGuardado = contenedoreRepository.agregar(escaneo, numeroContenedor);
            resposne.status = 1;
            resposne.mensaje = "Escaneo de Item: " + escaneoGuardado.codigoProducto + " agregado correctamente"; ;
            resposne.data = escaneoGuardado;

            return Ok(resposne);
        }


    }
}
