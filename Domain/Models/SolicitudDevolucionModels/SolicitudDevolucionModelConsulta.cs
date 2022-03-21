using Intermedia_.Repositories;
using SAP.Repositories;
using SAP.Repositories.Proveedor;
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
        public int docEntry { get; set;  }
        public string nombreProveedor { get; set; }
        public List<SolicitudDevolucionEntryResumenConsulta> entries { get; set; }

        //private
       private ProveedorSAPRepository proveedorSAPRepository { get; set; }
 

        public SolicitudDevolucionModelConsulta() {
            proveedorSAPRepository = new ProveedorSAPRepository();
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

            this.id = solicitudHeader.id;
            this.anulado = solicitudHeader.anulado;
            this.comentario = solicitudHeader.comentario;
            this.anulado = solicitudHeader.anulado;
            this.fechaCreacion = solicitudHeader.fecha;
            this.docEntry = solicitudHeader.docEntry;
            this.codigoProveedor = solicitudHeader.cardCode;
            this.codigoTienda = solicitudHeader.whsCode;
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

      


    }
}
