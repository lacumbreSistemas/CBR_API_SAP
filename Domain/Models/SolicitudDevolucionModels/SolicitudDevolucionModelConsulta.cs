using Intermedia_.Repositories;
using SAP.Models.SolicitudDevolicionEntrys;
using SAP.Repositories;
using SAP.Repositories.SolicitudesDevoliciones;
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
        public List <SolicitudDevolucionEntryResumenConsulta> _solicitudDevolucionEntryResumenList { get; set; }

        public SolicitudDevolucionModelConsulta() {
            _solicitudDevolucionEntryResumenList = new List<SolicitudDevolucionEntryResumenConsulta>();
        }

        public SolicitudDevolucionModelConsulta(int numero) {

            Numero = numero;
            obtenerHeader();

            _solicitudDevolucionEntryResumenList = new List<SolicitudDevolucionEntryResumenConsulta>();
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

            _SolicitudDevolucionEntryRepo.obtenerEntriesPornumber(Numero).Where(i=> !i.cancelado).GroupBy(i => new { i.number, i.itemCode }).ToList().ForEach(i => {

                SolicitudDevolucionEntryResumenConsulta _solicitudDevolucionEntryResumen = new SolicitudDevolucionEntryResumenConsulta(i.FirstOrDefault().itemCode);
                _solicitudDevolucionEntryResumen.Numero = this.Numero;
                _solicitudDevolucionEntryResumen.CantidadEscaneada = i.Sum(i=> i.quantity);
                _solicitudDevolucionEntryResumenList.Add(_solicitudDevolucionEntryResumen);

            });

        }

        //public SolicitudDevolucionModelConsulta generarEntradaMercancia() {


        //    SolicitudDevolucionSAPEntity solicitudDevolucionSAP = new SolicitudDevolucionSAPEntity();
        //    SolicitudesDevolucionesRepo solicitudesDevolucionesRepo = new SolicitudesDevolucionesRepo();

        //    solicitudDevolucionSAP.CardCode = ProveedorCode;
        //    solicitudDevolucionSAP.WhsCode = TiendaCode;

        //    _solicitudDevolucionEntryResumenList.ForEach(i =>
        //    {

        //        SolicitudDevolucionEntrySAPEntity solicitudDevolucionEntrySAPEntity = new SolicitudDevolucionEntrySAPEntity();
        //        solicitudDevolucionEntrySAPEntity.ItemCode = i.CodigoProducto;
        //        solicitudDevolucionEntrySAPEntity.Cantidad = (double) i.CantidadEscaneada; 

        //        solicitudDevolucionSAP.solicitudDevolucionEntrySAPEntities.Add(solicitudDevolucionEntrySAPEntity); 

        //    });

        //   DocEntry =  solicitudesDevolucionesRepo.generarSolicitudDevolicion(solicitudDevolucionSAP);

        //    return this;
        //}


    }
}
