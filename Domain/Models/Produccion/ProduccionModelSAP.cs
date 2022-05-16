using Intermedia_.Repositories.Produccion;
using SAP;
using SAP.Models.Mermas;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionModelSAP:ProduccionModelMaster

    {

        public int docEntrySalida { get; set;  }

        public int docEntryEntrada { get; set; }

        public int docNumSalida { get; set; }

        public int docNumEntrada { get; set; }


        public string cuentaContable { get; set; }

        public string centroCostoTienda { get; set; }
        public string centroCosto3 { get; set; }


        //public List<ProduccionEntryResumenConsultaMaster> entrys { get; set; }
     
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


        public ProduccionModelSAP generarSalidaMercancia()
        {
            SalidaMercanciaSAPEntity salidaMercanciaSAP = new SalidaMercanciaSAPEntity();
            SalidaMercanciaSAPRepo saliMercanciaRepo = new SalidaMercanciaSAPRepo();
            ProduccionHeaderRepo  produccionHeaderRepo = new ProduccionHeaderRepo();
            establecerCuentaContable();
            setCentroCosto();
            salidaMercanciaSAP.WhsCode = codigoTienda;
            salidaMercanciaSAP.Comentario = comentario;
            salidaMercanciaSAP.RemarkID = remarkCode;
            salidaMercanciaSAP.Remark = remark;
            salidaMercanciaSAP.UsuarioEncargado = usuario;
            salidaMercanciaSAP.CuentaContable = cuentaContable;
            salidaMercanciaSAP.Remark = remark;
            salidaMercanciaSAP.CentroCosto = centroCostoTienda;
            salidaMercanciaSAP.CentroCosto3 = centroCosto3;


            SalidaMercanciaSAPEntryEntity salidaMercanciaEntrys = new SalidaMercanciaSAPEntryEntity();
            salidaMercanciaEntrys.ItemCode = codigoProducto;
            salidaMercanciaEntrys.Cantidad = (double)i.cantidadEscaneada;

            salidaMercanciaSAP.mermasSAPEntryEntity.Add(salidaMercanciaEntrys);

            //entrys.ForEach(i =>
            //{

            //    SalidaMercanciaSAPEntryEntity salidaMercanciaEntrys = new SalidaMercanciaSAPEntryEntity();
            //    salidaMercanciaEntrys.ItemCode = i.codigoProducto;
            //    salidaMercanciaEntrys.Cantidad = (double)i.cantidadEscaneada;

            //    salidaMercanciaSAP.mermasSAPEntryEntity.Add(salidaMercanciaEntrys);

            //});
            docEntrySalida = saliMercanciaRepo.generarSalidaMercancia(salidaMercanciaSAP);

            produccionHeaderRepo.setEntradaDocEntry(numero, docEntrySalida);

            return this;

        }


    }
}
