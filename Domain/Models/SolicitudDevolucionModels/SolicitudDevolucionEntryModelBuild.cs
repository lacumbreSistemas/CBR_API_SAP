using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
   public class SolicitudDevolucionEntryModelBuild
    {
        //public

        public string itemCode { get; set; }
        public double cantidad { get; set; }
        public DateTime fecha { get; set; }
        public bool deleted { get; set; }
        public int deletedId { get; set; }
        public string usuario { get; set; }
        public int numero { get; set; }


        //privates
        private cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo { get; set; }


        public SolicitudDevolucionEntryModelBuild() {
          
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();

        }


        public SolicitudDevolucionEntryModelBuild(SolicitudDevolucionEntryModelBuild _solicitudDevolucionEntryModelBuild)
        {
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();

            itemCode = _solicitudDevolucionEntryModelBuild.itemCode;
            cantidad = _solicitudDevolucionEntryModelBuild.cantidad;
            fecha = _solicitudDevolucionEntryModelBuild.fecha;
            deleted = _solicitudDevolucionEntryModelBuild.deleted;
            deletedId = _solicitudDevolucionEntryModelBuild.deletedId;
            numero = _solicitudDevolucionEntryModelBuild.numero;
            usuario = _solicitudDevolucionEntryModelBuild.usuario;

        }


        public SolicitudDevolucionEntryModelBuild guardar() {
            cbr_SolicitudDevolucionEntry _cbr_SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntry();

            fecha = DateTime.Now;
            deleted = false;
            deletedId = 0;

            _cbr_SolicitudDevolucionEntryRepo.itemCode = itemCode;
            _cbr_SolicitudDevolucionEntryRepo.number = numero;
            _cbr_SolicitudDevolucionEntryRepo.quantity = cantidad;
            _cbr_SolicitudDevolucionEntryRepo.usuario = usuario;
            _cbr_SolicitudDevolucionEntryRepo.deleted = deleted;
            _cbr_SolicitudDevolucionEntryRepo.deletedId = deletedId;
            _cbr_SolicitudDevolucionEntryRepo.fecha = fecha; 


            _SolicitudDevolucionEntryRepo.crearCbr_SolicitudDevolucionEntry(_cbr_SolicitudDevolucionEntryRepo);


            return this;
        
        }

        //constructores

    }
}
