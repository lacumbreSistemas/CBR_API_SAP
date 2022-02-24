using Intermedia_.Repositories;
using SAP.Repositories.ComprasInternacionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ContenedorListaModels
{
    public class ContenedorListaModelEntry
    {
        public string numeroContenedor { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public double cantidadEscaneada { get; set; }

      
        public ContenedorListaModelEntry() {
        }



    }
}
