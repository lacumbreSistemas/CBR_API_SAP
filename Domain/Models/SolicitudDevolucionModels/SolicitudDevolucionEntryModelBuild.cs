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
   public class SolicitudDevolucionEntryModelBuild: SolicitudDevolucionEntryModelMaster 
    {


        private cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo { get; set; }

       

        public SolicitudDevolucionEntryModelBuild() {

            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();

        }


        public SolicitudDevolucionEntryModelBuild(SolicitudDevolucionEntryModelBuild _solicitudDevolucionEntryModelBuild)
        {
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();

            CodigoProducto = _solicitudDevolucionEntryModelBuild.CodigoProducto;
            cantidad = _solicitudDevolucionEntryModelBuild.cantidad;
            fecha = _solicitudDevolucionEntryModelBuild.fecha;
            deleted = _solicitudDevolucionEntryModelBuild.deleted;
            deletedId = _solicitudDevolucionEntryModelBuild.deletedId;
            numero = _solicitudDevolucionEntryModelBuild.numero;
            usuario = _solicitudDevolucionEntryModelBuild.usuario;
            setNombreProducto();

         
        }


        public SolicitudDevolucionEntryModelBuild guardar() {
            cbr_SolicitudDevolucionEntry _cbr_SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntry();

            //fecha = DateTime.Now;
            //deleted = false;
            //deletedId = 0;


            _cbr_SolicitudDevolucionEntryRepo.itemCode = CodigoProducto;
            _cbr_SolicitudDevolucionEntryRepo.number = numero;
            _cbr_SolicitudDevolucionEntryRepo.quantity = cantidad;
            _cbr_SolicitudDevolucionEntryRepo.usuario = usuario;
            _cbr_SolicitudDevolucionEntryRepo.deleted = false;
            _cbr_SolicitudDevolucionEntryRepo.deletedId = 0;
            _cbr_SolicitudDevolucionEntryRepo.fecha = DateTime.Now;
            _cbr_SolicitudDevolucionEntryRepo.cancelado = false; 

            _SolicitudDevolucionEntryRepo.crearCbr_SolicitudDevolucionEntry(_cbr_SolicitudDevolucionEntryRepo);


            return this;
        
        }

        //constructores

    }
}
