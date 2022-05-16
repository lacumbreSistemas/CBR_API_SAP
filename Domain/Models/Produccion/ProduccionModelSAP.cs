using SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionModelSAP:ProduccionModelMaster

    {

        public string docEntrySalida { get; set;  }

        public string docEntryEntrada { get; set; }

        public string docNumSalida { get; set; }

        public string docNumEntrada { get; set; }


        public string cuentaContable { get; set; }

        public string centroCostoTienda { get; set; }
        public string centroCosto3 { get; set; }


        public List<ProduccionEntryResumenConsultaMaster> entryResumenConsultaMasters { get; set; }
     
        private void establecerCuentaContable() {
            RemarksRepo remarksRepo = new RemarksRepo();
            cuentaContable = remarksRepo.obgenerCuentaContable(remarkCode);

        }

        private void setCentroCosto()
        {
            RemarksRepo remarksRepo = new RemarksRepo();
            Intermedia_.Repositories.CentroCostoRepository centroCostoRepository = new Intermedia_.Repositories.CentroCostoRepository();
            centroCostoTienda = centroCostoRepository.obtenerCentroCostoTienda(codigoTienda);
            centroCosto3 = remarksRepo.obtenerCentroCosto(remarkCode);
        }
    }
}
