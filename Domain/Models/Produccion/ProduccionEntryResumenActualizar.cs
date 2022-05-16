using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionEntryResumenActualizar:ProduccionEntryResumenConsultaMaster
    {
        public ProduccionEntryResumenActualizar(string itemCode, int numero) {
            this.numero = numero;
            this.codigoProducto = itemCode; 
        }

        public ProduccionEntryResumenActualizar() { 
        
        
        }


        public string Anular() {
            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

            bool itemCancelados = produccionEntryRepo.cancelarItem(numero, codigoProducto);

            if (itemCancelados)
            {
                throw new Exception("El item " + descripcionProducto + " ya había sido cancelado");
            }


            return "Item " + this.descripcionProducto + " cancelado exitosamente";

        }
    }
}
