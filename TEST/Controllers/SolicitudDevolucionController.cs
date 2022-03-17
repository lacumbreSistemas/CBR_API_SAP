﻿using Domain.Models.SolicitudDevolucionModels;
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


        [HttpGet("{Whscode}")]
        public IActionResult solititudDevolucion(string Whscode)
        {
      

            _Response.mensaje = "Lista de solicitudes de devolucion para tienda "+Whscode;
            _Response.data = SolicitudDevolucionRepo.obtenerListaSolicitudesDevolucionSinDocentry(Whscode); ;


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
        public IActionResult guardarSolicitudDevolusion([FromBody] SolicitudDevolucionModelBuild solicitudTraslado)
        {
            var guardarSolicitudDevolucion = SolicitudDevolucionRepo.crearSolicitudDevolucionIntermedia(solicitudTraslado);

            _Response.mensaje = "Solicitud de traslado " + guardarSolicitudDevolucion.Numero + " guardada con éxito";
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
    }
}
