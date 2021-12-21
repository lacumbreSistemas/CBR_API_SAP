using Domain.Interfaces;
using SAP.Repositories.ComprasInternacionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComrpasModels
{
    public class EscaneoBuildInternacionalEstrategia : IEscaneoBuildEstrategia
    {

        private FacturaReservaEntryRepository sapEntryRepository { get; set; }


        public EscaneoBuildInternacionalEstrategia() {

            sapEntryRepository =new FacturaReservaEntryRepository();
        }

        public double ObtenerCantidadOrdenada(int? docEntry, string itemCode)
        {
            return sapEntryRepository.ObtenerCantidadOrdenada(docEntry, itemCode);
        }

        public int obtenerLineNum(int? docEntry, string itemCode)
        {
            return sapEntryRepository.obtenerLineNum(docEntry, itemCode);
        }
    }
}
