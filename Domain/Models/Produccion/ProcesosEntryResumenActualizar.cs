using Domain.Interfaces;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProcesosEntryResumenActualizar:ProcesosEntryResumenMaster
    {

        public IModelEntryResumenProcesos Estrategia { get; set; }
        public ProcesosEntryResumenActualizar(string itemCode, int numero, IModelEntryResumenProcesos estrategia) {
            this.numero = numero;
            Estrategia = estrategia;
            this.codigoProducto = itemCode; 
        }

        public ProcesosEntryResumenActualizar(IModelEntryResumenProcesos estrategia) {
            Estrategia = estrategia;

        }
         public ProcesosEntryResumenActualizar() { 
        
        
        }


        public string Anular() {

            return Estrategia.Anular(numero,codigoProducto,descripcionProducto);

        }
    }
}
