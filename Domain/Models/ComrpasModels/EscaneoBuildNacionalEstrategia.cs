using Domain.Interfaces;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ComrpasModels
{
    public class EscaneoBuildNacionalEstrategia : IEscaneoBuildEstrategia
    {

        private PurchaseOrderEntryRespository sapEntryRepository { get; set; }

        public EscaneoBuildNacionalEstrategia() {
            sapEntryRepository = new PurchaseOrderEntryRespository(); 
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
