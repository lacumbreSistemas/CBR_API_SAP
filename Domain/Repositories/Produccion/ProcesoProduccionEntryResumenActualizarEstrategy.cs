using Domain.Interfaces;
using Intermedia_.Repositories.Produccion;
using Intermedia_.Repositories.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class ProcesoProduccionEntryResumenActualizarEstrategy : IModelEntryResumenProcesos
    {
        public string Anular(int numero, string codigoProducto, string descripcionProducto)
        {
            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

            bool itemCancelados = produccionEntryRepo.cancelarItem(numero, codigoProducto);

            if (itemCancelados)
            {
                throw new Exception("El item " + descripcionProducto + " ya había sido cancelado");
            }


            return "Item " + descripcionProducto + " cancelado exitosamente";

        }
    }
}

