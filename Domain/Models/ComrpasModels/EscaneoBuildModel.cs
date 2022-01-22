using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedia_.Repositories;
using SAP.Repositories;
using Intermedia_;
using Domain.Interfaces;

namespace Domain.Models
{
   public class EscaneoBuildModel: EscaneoMasterModel
    {

       
    

        //privaate

        private cbr_ComprasSAP_Escaneo_Repository intermediaEscaneoRepository { get; set; }
        //private PurchaseOrderEntryRespository sapEntryRepository { get; set; }

        private IEscaneoBuildEstrategia _estrategia { get; set; } 

        //constructores
        public EscaneoBuildModel() {
          
        }

       
       public EscaneoBuildModel(EscaneoBuildModel newEscaneo, IEscaneoBuildEstrategia estrategia)
        {

            ordenCompraDocEntry = newEscaneo.ordenCompraDocEntry;
            codigoProducto = newEscaneo.codigoProducto;
            usuario = newEscaneo.usuario;
            cantidad = newEscaneo.cantidad;
            fecha = DateTime.Now;
            //matriculado = newEscaneo.matriculado;
            intermediaEscaneoRepository = new cbr_ComprasSAP_Escaneo_Repository();

            _estrategia = estrategia;
            //sapEntryRepository = new PurchaseOrderEntryRespository();

        }

        //metodos
                public EscaneoBuildModel agreagar() {
                    _estrategia.GuardarEscaneo(this);
                    return this;
                }

    }
}
