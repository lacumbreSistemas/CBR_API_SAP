using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionModelConsulta: SolicitudDevolucionModelMaster
    {
        public int id { get; set; }
        public int DocEntry { get; set;  } 

     
      //private
        public List <SolicitudDevolucionEntryResumen> _solicitudDevolucionEntryResumenList { get; set; }

        public SolicitudDevolucionModelConsulta() { 
        
        }

        public SolicitudDevolucionModelConsulta(int numero) {

            Numero = numero;
            obtenerHeader();

            _solicitudDevolucionEntryResumenList = new List<SolicitudDevolucionEntryResumen>();


        }


        private void obtenerHeader() {
            cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();
            var solicitudHeader = _SolicitudDevolucionHeaderRepo.obtenerSolicitudIntermediaNumber(Numero);

            this.id = solicitudHeader.id;
            this.Anulado = solicitudHeader.anulado;
            this.Comentario = solicitudHeader.comentario;
            this.Anulado = solicitudHeader.anulado;
            this.Fecha = solicitudHeader.fecha;
            this.DocEntry = solicitudHeader.docEntry;
            this.ProveedorCode = solicitudHeader.cardCode;
            this.TiendaCode = solicitudHeader.whsCode;
           

        }

        public void resumenEntries()
        {

         
            cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();

            _SolicitudDevolucionEntryRepo.obtenerEntriesPornumber(Numero).GroupBy(i => new { i.number, i.itemCode }).ToList().ForEach(i => {

                SolicitudDevolucionEntryResumen _solicitudDevolucionEntryResumen = new SolicitudDevolucionEntryResumen(i.FirstOrDefault().itemCode);
                _solicitudDevolucionEntryResumen.CantidadEscaneada = i.Sum(i=> i.quantity);
                _solicitudDevolucionEntryResumenList.Add(_solicitudDevolucionEntryResumen);

            });

        }
    }
}
