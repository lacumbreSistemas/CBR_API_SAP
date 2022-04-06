using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
    public class MermasEntryResumenActualizar:MermaEntryResumenMaster
    {
        public MermasEntryResumenActualizar(string itemCode, int numero) {

            this.numero = numero;
            this.codigoProducto = itemCode; 
       
        }

        public MermasEntryResumenActualizar() { 
          
        
        }


        public string anular() {

            MermasEntryRepo mermasEntryRepo = new MermasEntryRepo();
            bool itemsCancelados = mermasEntryRepo.cancelarItem(numero,codigoProducto);

            if (itemsCancelados)
            {
                throw new Exception("El item " + descripcionProducto + " ya había sido cancelado");
            }


            return "Item " + this.descripcionProducto + " cancelado exitosamente";

        }
    }
}
