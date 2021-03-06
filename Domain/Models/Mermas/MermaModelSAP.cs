
using Intermedia_.Repositories;
using SAP;
using SAP.Models.Mermas;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Models.Mermas
{
    public class MermaModelSAP : MermasModelMaster
    {

        public int DocEntry { get; set; }
        public int DocNum { get; set; }

        public string cuentaContable {get; set;}



        //centro de costo 

        public string CentroCostoTienda { get; set; }
        public string centroCosto3 { get; set; }

        public List<MermaEntryResumenMaster> mermasEntryList = new List<MermaEntryResumenMaster>();

        private void setCuentaContable() {
            SalidaMercanciaPreliminarSAPRepo MermasDevolucionesRepo = new SalidaMercanciaPreliminarSAPRepo();

            cuentaContable = MermasDevolucionesRepo.obgenerCuentaContable(remarkCode);

        }

        private void setCentroCosto() {
            RemarksRepo remarksRepo = new RemarksRepo();
         
            //centroCosto3 =  remarksRepo.obtenerCentroCosto(remarkCode);

            var CentroCosto = remarksRepo.obtenerCentroCosto(remarkCode);

            var centrosCostosSeparados = CentroCosto.ToString().Split(';');
            int index = 1; 
            foreach (string centrocosto in centrosCostosSeparados) {


                if (CentroCostoTienda != "" && index == 1) 
                    CentroCostoTienda = centrocosto;

                if (CentroCostoTienda != "" && index == 3)
                    centroCosto3 = centrocosto;

                index++;
            }



        }
        public MermaModelSAP generarMermaDevolucion()
        {
            SalidaMercanciaSAPEntity MermasSAP = new SalidaMercanciaSAPEntity();
            SalidaMercanciaPreliminarSAPRepo MermasDevolucionesRepo = new SalidaMercanciaPreliminarSAPRepo();
            MermasHeaderRepo mermasHeaderRepo = new MermasHeaderRepo();
            setCuentaContable();
            setCentroCosto();
            MermasSAP.WhsCode = codigoTienda;
            MermasSAP.Comentario = comentario;
            MermasSAP.RemarkID = remarkCode;
            MermasSAP.Remark = remark;
            MermasSAP.UsuarioEncargado = usuario;
            MermasSAP.CuentaContable = cuentaContable;
            MermasSAP.Remark = remark;
            MermasSAP.CentroCosto = CentroCostoTienda;
            MermasSAP.CentroCosto3 = centroCosto3;

            mermasEntryList.ForEach(i =>
            {

                SalidaMercanciaSAPEntryEntity solicitudDevolucionEntrySAPEntity = new SalidaMercanciaSAPEntryEntity();
                solicitudDevolucionEntrySAPEntity.ItemCode = i.codigoProducto;
                solicitudDevolucionEntrySAPEntity.Cantidad = (double)i.cantidadEscaneada;

                MermasSAP.mermasSAPEntryEntity.Add(solicitudDevolucionEntrySAPEntity);

            });
            DocEntry = MermasDevolucionesRepo.generarSalidaMercancia(MermasSAP);

            mermasHeaderRepo.setIfSAP(numero);

            return this;

        }

    }

}
