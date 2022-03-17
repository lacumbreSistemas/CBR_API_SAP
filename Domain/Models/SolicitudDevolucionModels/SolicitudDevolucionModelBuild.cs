using Domain.Interfaces;
using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionModelBuild:SolicitudDevolucionModelMaster
    {



       
    //privates 
    cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo { get; set;     }
        private SolicitudDevolucionModelBuildEstrategia Estrategia { get; set; }
        //constructor

        public SolicitudDevolucionModelBuild() {
            _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
        }

        public SolicitudDevolucionModelBuild(SolicitudDevolucionModelBuild solicitudDevolucion)
        {
            TiendaCode = solicitudDevolucion.TiendaCode;
            ProveedorCode = solicitudDevolucion.ProveedorCode;
            Fecha = DateTime.Now;
            Comentario = solicitudDevolucion.Comentario;
     


            _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
        }



        public SolicitudDevolucionModelBuild guardar() {
            cbr_SolicitudDevolucionHeader _solicitudDevolucionHeader = new cbr_SolicitudDevolucionHeader();

            _solicitudDevolucionHeader.cardCode = ProveedorCode;
            _solicitudDevolucionHeader.whsCode = TiendaCode;
        
            _solicitudDevolucionHeader.fecha =Fecha;
            _solicitudDevolucionHeader.number = Numero;
            _solicitudDevolucionHeader.comentario = Comentario;
            _solicitudDevolucionHeader.anulado = false; 

            Numero =  _SolicitudDevolucionHeaderRepo.crearCbr_SolicitudDevolucionHeader(_solicitudDevolucionHeader);

            return this;

        }

    }
}
