
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

        public string centroCostoTienda { get; set; }
        public string centroCosto3 { get; set; }

        public List<MermaEntryResumenMaster> mermasEntryList = new List<MermaEntryResumenMaster>();

        private void setCuentaContable() {
            MermasSAPRepo MermasDevolucionesRepo = new MermasSAPRepo();

            cuentaContable = MermasDevolucionesRepo.obgenerCuentaContable(remarkCode);

        }

        private void setCentroCosto() {
            RemarksRepo remarksRepo = new RemarksRepo();
            Intermedia_.Repositories.CentroCostoRepository centroCostoRepository = new Intermedia_.Repositories.CentroCostoRepository();
            centroCostoTienda =   centroCostoRepository.obtenerCentroCostoTienda(codigoTienda);
            centroCosto3 =  remarksRepo.obtenerCentroCosto(remarkCode);
        }
        public MermaModelSAP generarMermaDevolucion()
        {
            MermasSAPEntity MermasSAP = new MermasSAPEntity();
            MermasSAPRepo MermasDevolucionesRepo = new MermasSAPRepo();
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
            MermasSAP.CentroCosto = centroCostoTienda;
            MermasSAP.CentroCosto3 = centroCosto3;

            mermasEntryList.ForEach(i =>
            {

                MermasSAPEntryEntity solicitudDevolucionEntrySAPEntity = new MermasSAPEntryEntity();
                solicitudDevolucionEntrySAPEntity.ItemCode = i.codigoProducto;
                solicitudDevolucionEntrySAPEntity.Cantidad = (double)i.cantidadEscaneada;

                MermasSAP.mermasSAPEntryEntity.Add(solicitudDevolucionEntrySAPEntity);

            });
            DocEntry = MermasDevolucionesRepo.generarMerma(MermasSAP);

            mermasHeaderRepo.setIfSAP(numero);

            return this;

        }

    }

}
