using Domain.Interfaces;
using Domain.Models.SolicitudDevolucionModels;
using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.SolicitudDevolucionRepositories
{
    public class SolicitudDevolucionRepo
    {
        
        private cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
     

        public SolicitudDevolucionModelBuild crearSolicitudDevolucionIntermedia(SolicitudDevolucionModelBuild solicitudDevolucion,string WhsCode)
        {
            SolicitudDevolucionModelBuild nuevaSolicitudDevolucionModel = new SolicitudDevolucionModelBuild(solicitudDevolucion);
            nuevaSolicitudDevolucionModel.codigoTienda = WhsCode;
           nuevaSolicitudDevolucionModel.guardar();
           return nuevaSolicitudDevolucionModel.numeroDevolucion == 0 ? throw new Exception("No se creó solicitud de devolución"): nuevaSolicitudDevolucionModel;

        }


        public List<SolicitudDevolucionModelConsulta> obtenerListaSolicitudesDevolucionSinDocentry(string WhsCode) {

            List<cbr_SolicitudDevolucionHeader> solicitudesDevolucionIntermedia = new List<cbr_SolicitudDevolucionHeader>();

            solicitudesDevolucionIntermedia =  _SolicitudDevolucionHeaderRepo.obtenerSolicitudesDevolucionSinDocEntry(WhsCode).ToList();
            
            List<SolicitudDevolucionModelConsulta> solicituddesDevolucion = new List<SolicitudDevolucionModelConsulta>();

            solicitudesDevolucionIntermedia.ForEach(i =>
            {
                SolicitudDevolucionModelConsulta solicitudDevolucion = new SolicitudDevolucionModelConsulta();
                //solicitudDevolucion.id = i.id;
                solicitudDevolucion.numeroDevolucion = i.number;
                solicitudDevolucion.codigoProveedor = i.cardCode;
                solicitudDevolucion.codigoTienda = i.whsCode;
                solicitudDevolucion.fechaCreacion = i.fecha;
                solicitudDevolucion.usuario = i.usuario;

                solicitudDevolucion.setNombreProveedor();

                solicituddesDevolucion.Add(solicitudDevolucion);

            });

            return solicituddesDevolucion;
        }

     
        public SolicitudDevolucionModelConsulta resumenSolicitudDevolucion(int numero) {
            SolicitudDevolucionModelConsulta solicitudDevolucionModelConsulta = new SolicitudDevolucionModelConsulta(numero);

            solicitudDevolucionModelConsulta.resumenEntries();

            return solicitudDevolucionModelConsulta; 

        }

        public void anularEscaneosItemCodeNumero(SolicitudDevolucionEntryResumenActualizar solicitudDevolucionEntryResumenActualizar) {

            solicitudDevolucionEntryResumenActualizar.anular();


        }

        public SolicitudDevolucionModelSAP generarSolicitudDevolucionSAP(int numero) {


            var solicitudDevolucionIntermedia  = resumenSolicitudDevolucion(numero);

            SolicitudDevolucionModelSAP solicitudDevolucionSAP = new SolicitudDevolucionModelSAP();

            solicitudDevolucionSAP.numeroDevolucion = solicitudDevolucionIntermedia.numeroDevolucion;
            solicitudDevolucionSAP.codigoProveedor = solicitudDevolucionIntermedia.codigoProveedor;
            solicitudDevolucionSAP.codigoTienda = solicitudDevolucionIntermedia.codigoTienda;
            solicitudDevolucionSAP.comentario = solicitudDevolucionIntermedia.comentario;
            solicitudDevolucionSAP.usuario = solicitudDevolucionIntermedia.usuario;


            if (solicitudDevolucionIntermedia.entries.Count == 0)
                throw new Exception("No tiene items escaneados para subir");

            solicitudDevolucionIntermedia.entries.ForEach(i =>
            {
                solicitudDevolucionSAP._solicitudDevolucionEntryResumenList.Add(i);

            });


            if (solicitudDevolucionIntermedia.docEntry > 0) 
                throw new Exception("Ya se generó un documento de SAP para esta devolucion"); 
            


            return solicitudDevolucionSAP.generarSolicitudDevolucion();

        }

        public string  cancelarSolicitud(int numero) {
            _SolicitudDevolucionHeaderRepo.cancelarSolicitud(numero);
            return "Solicitud cancelada";
        }
             

    }
}
