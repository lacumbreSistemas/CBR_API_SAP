using Intermedia_.Repositories;
using Intermedia_;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using SAP.Repositories.Compras;

namespace Domain.Models
{
    public class PurchaseOrderEntryModel: IOCEntry
    {


        //Publics
        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public  double cantidadOrdenada { get; set; }
        public double cantidadEscaneada { get; set; }
        
        public double canridadIngresada { get; set; }


        //Privates
     
        private cbr_ComprasSAP_Escaneo_Repository intermediaEntryRepository { get; set; }

        //private PurchaseOrderEntryRespository entriesRepository { get; set; }

        //Constructores

        //public PurchaseOrderEntryModel(int docEntry, string nombreProducto)
        //{
        //    intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
        //    this.docEntry = docEntry;
        //    this.nombreProducto = nombreProducto;
        //    this.codigoProducto = codigoProducto;
        
        //    this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadRecibida(docEntry, codigoProducto);
        //}

        public PurchaseOrderEntryModel()
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadEscaneadaNoIngresada(docEntry, codigoProducto);
            obtenerCantidadIngresadaSAP();
        }

        public PurchaseOrderEntryModel(int docentry, string itemCode)
        {
            this.docEntry = docentry;
            this.codigoProducto = itemCode;
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            obtenerCantidadIngresadaSAP();
            this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadEscaneadaNoIngresada(docEntry, codigoProducto);

        }


        private void obtenerCantidadIngresadaSAP() {

              EntradaDeMercanciaEntryRepository entradaDeMercanciaEntryRepository = new EntradaDeMercanciaEntryRepository();
            canridadIngresada = entradaDeMercanciaEntryRepository.ObtenerCantidadIngresada(this.docEntry, this.codigoProducto);

        }
        public PurchaseOrderEntryModel(PurchaseOrderEntryModel newEntry)
        {
            intermediaEntryRepository = new cbr_ComprasSAP_Escaneo_Repository();
            obtenerCantidadIngresadaSAP();
            this.docEntry = newEntry.docEntry;
            this.nombreProducto = newEntry.nombreProducto;
            this.codigoProducto = newEntry.codigoProducto;
            this.cantidadOrdenada = newEntry.cantidadOrdenada;
            this.cantidadEscaneada = this.intermediaEntryRepository.obtenerCantidadEscaneadaNoIngresada(docEntry, codigoProducto);
        }

     
            
    }
}
