﻿using Domain.Interfaces;
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
    //cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo { get; set;     }
  
        //constructor

        public SolicitudDevolucionModelBuild() {
            //_SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
        }

        public SolicitudDevolucionModelBuild(SolicitudDevolucionModelBuild solicitudDevolucion, SolicitudDevolucionModelBuildEstrategia estrategia)
        {
            TiendaCode = solicitudDevolucion.TiendaCode;
            ProveedorCode = solicitudDevolucion.ProveedorCode;
            Fecha = DateTime.Now;
            Comentario = solicitudDevolucion.Comentario;
        


            //_SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
        }



        public SolicitudDevolucionModelBuild guardar() {

            cbr_SolicitudDevolucionHeader _solicitudDevolucionHeader = new cbr_SolicitudDevolucionHeader();
            cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();

            _solicitudDevolucionHeader.cardCode = codigoProveedor;
            _solicitudDevolucionHeader.whsCode = codigoTienda;
        
            _solicitudDevolucionHeader.fecha =fechaCreacion;
            _solicitudDevolucionHeader.number = numeroDevolucion;
            _solicitudDevolucionHeader.comentario = comentario;
            _solicitudDevolucionHeader.anulado = false; 

            numeroDevolucion =  _SolicitudDevolucionHeaderRepo.crearCbr_SolicitudDevolucionHeader(_solicitudDevolucionHeader);

            return this;
        }

    }
}
