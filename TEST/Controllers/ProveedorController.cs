using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : Controller
    {

        public Response _Response { get; set; }
        public ProveedorRepository _ProveedorRepository { get; set;}
        public ProveedorController() {
            _Response = new Response();
            _ProveedorRepository = new ProveedorRepository();
        }

        [HttpGet()]
        public IActionResult listaProveedores() {

            _Response.mensaje = "Lista de proveedores";
            _Response.data = _ProveedorRepository.listaProveedores();

            return Ok(_Response);
        }
    }
}
