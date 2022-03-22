using Intermedia_;
using Intermedia_.Repositories;
using SAP.Models.SolicitudDevolicionEntrys;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryModelConsulta: SolicitudDevolucionEntryModelMaster 
    {
        
        //public
        public int id { get; set; }
        public bool cancelado { get; set; }


       
        //private
        private cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo { get; set; }

        public SolicitudDevolucionEntryModelConsulta(string CodigoProducto) {
            this.CodigoProducto = CodigoProducto;
            setNombreProducto();
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();
        }
        public SolicitudDevolucionEntryModelConsulta()
        {
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();
        }


        public SolicitudDevolucionEntryModelConsulta anular() {

          
           

            cbr_SolicitudDevolucionEntry escaneoAnuladoEntity =  _SolicitudDevolucionEntryRepo.anularEntrieEscaneo(this.id);

            SolicitudDevolucionEntryModelConsulta escaneoAnulado = new SolicitudDevolucionEntryModelConsulta();

            escaneoAnulado.id = escaneoAnuladoEntity.id;
            escaneoAnulado.deletedId = escaneoAnuladoEntity.deletedId;
            escaneoAnulado.fecha = escaneoAnuladoEntity.fecha;
            escaneoAnulado.CodigoProducto = escaneoAnuladoEntity.itemCode;
            escaneoAnulado.numero = escaneoAnuladoEntity.number;
            escaneoAnulado.cantidad = escaneoAnuladoEntity.quantity;
            escaneoAnulado.usuario = escaneoAnuladoEntity.usuario;
            escaneoAnulado.deleted = escaneoAnuladoEntity.deleted;


            return escaneoAnulado;



        }


      







    }
}
