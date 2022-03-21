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
     

        public SolicitudDevolucionModelBuild crearSolicitudDevolucionIntermedia(SolicitudDevolucionModelBuild solicitudDevolucion, string WhsCode)
        {
            SolicitudDevolucionBuildIntermediaEstrategia estrategia = new SolicitudDevolucionBuildIntermediaEstrategia();
            solicitudDevolucion.codigoTienda = WhsCode;
            SolicitudDevolucionModelBuild nuevaSolicitudDevolucionModel = new SolicitudDevolucionModelBuild(solicitudDevolucion, estrategia);
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
                solicitudDevolucion.id = i.id;
                solicitudDevolucion.numeroDevolucion = i.number;
                solicitudDevolucion.codigoProveedor = i.cardCode;
                solicitudDevolucion.codigoTienda = i.whsCode;
                solicitudDevolucion.fechaCreacion = i.fecha;

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
       
        

    }
}
