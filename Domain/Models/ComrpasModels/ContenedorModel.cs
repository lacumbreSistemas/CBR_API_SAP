using SAP.Repositories.ComprasInternacionalesContenedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComrpasModels
{
    public class ContenedorModel
    {


        public string numeroContenedor { get; set; }
       
        public List<PurchaseOrderModel> ordenesCompra { get; set; }


        //private
        

        public ContenedorModel(string _numeroContenedor) {


            numeroContenedor = _numeroContenedor;
            ordenesCompra = new List<PurchaseOrderModel>();
            obtenerFacturasRerserve();
           
        }

        public ContenedorModel() {
            ordenesCompra = new List<PurchaseOrderModel>();

        }


       

        private void obtenerFacturasRerserve() {
            ComprasInternacionalesContenedorRepository comprasInternacionalesContenedorRepository = new ComprasInternacionalesContenedorRepository();

            var facturasReserva =  comprasInternacionalesContenedorRepository.obtenerOrdenesCompraPorNumeroContenedor(numeroContenedor);
            facturasReserva.ForEach(oc=> {
                PurchaseOrderModel ordenCompra = new PurchaseOrderModel();

                ordenCompra.docEntry = oc.docEntry;
                ordenCompra.numeroOrdenDeCompra = oc.docNum;
                ordenCompra.codigoProveedor = oc.cardCode;
                ordenCompra.nombreProveedor = oc.cardName;
                ordenCompra.fechaCreacion = oc.docDueDate;
                ordenCompra.fechaEntrega = oc.taxDate;
                ordenesCompra.Add(ordenCompra);

            });

        }

    }
}
