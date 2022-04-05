using Intermedia_.Repositories;
using SAP.Models.SolicitudDevolicionEntrys;
using SAP.Repositories;
using SAP.Repositories.Proveedor;
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
       
        public int docEntry { get; set;  }
        public string nombreProveedor { get; set; }
        public List<SolicitudDevolucionEntryResumenConsulta> entries { get; set; }

        //private
       private ProveedorSAPRepository proveedorSAPRepository { get; set; }
 

        public SolicitudDevolucionModelConsulta() {
            proveedorSAPRepository = new ProveedorSAPRepository();
            entries = new List<SolicitudDevolucionEntryResumenConsulta>();
        }

        public SolicitudDevolucionModelConsulta(int numero) {
            proveedorSAPRepository = new ProveedorSAPRepository();
             entries = new List<SolicitudDevolucionEntryResumenConsulta>();
            numeroDevolucion = numero;
          
            obtenerHeader();
          
           
            
        }


        private void obtenerHeader() {
            cbr_SolicitudDevolucionHeaderRepo _SolicitudDevolucionHeaderRepo = new cbr_SolicitudDevolucionHeaderRepo();

          
            var solicitudHeader = _SolicitudDevolucionHeaderRepo.obtenerSolicitudIntermediaNumber(numeroDevolucion);

            //this.id = solicitudHeader.id;
            this.anulado = solicitudHeader.anulado;
            this.comentario = solicitudHeader.comentario;
           
            this.fechaCreacion = solicitudHeader.fecha;
            this.docEntry = solicitudHeader.docEntry;
            this.codigoProveedor = solicitudHeader.cardCode;
            this.codigoTienda = solicitudHeader.whsCode;
            this.usuario = solicitudHeader.usuario;
            setNombreProveedor();

        }

        public void setNombreProveedor() {
       
            var proveedor = proveedorSAPRepository.obtenerProveedorCodigo(codigoProveedor);
            nombreProveedor = proveedor.Nombre;

        }
        public void resumenEntries()
        {

         
            cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();

            _SolicitudDevolucionEntryRepo.obtenerEntriesPornumber(numeroDevolucion).Where(i=> !i.cancelado).GroupBy(i => new { i.number, i.itemCode }).ToList().ForEach(i => {

                SolicitudDevolucionEntryResumenConsulta _solicitudDevolucionEntryResumen = new SolicitudDevolucionEntryResumenConsulta(i.FirstOrDefault().itemCode);
                _solicitudDevolucionEntryResumen.Numero = this.numeroDevolucion;
                _solicitudDevolucionEntryResumen.CantidadEscaneada = i.Sum(i=> i.quantity);
                entries.Add(_solicitudDevolucionEntryResumen);

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
