
using Intermedia_.Repositories;
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

        public List<MermaEntryResumenMaster> mermasEntryList = new List<MermaEntryResumenMaster>();

        private void setCuentaContable() {
            MermasSAPRepo MermasDevolucionesRepo = new MermasSAPRepo();

            cuentaContable = MermasDevolucionesRepo.obgenerCuentaContable(remarkCode);

        }
        public MermaModelSAP generarMermaDevolucion()
        {


            MermasSAPEntity MermasSAP = new MermasSAPEntity();
            MermasSAPRepo MermasDevolucionesRepo = new MermasSAPRepo();
            MermasHeaderRepo mermasHeaderRepo = new MermasHeaderRepo();
            setCuentaContable();

            MermasSAP.WhsCode = codigoTienda;
            MermasSAP.Comentario = comentario;
            MermasSAP.RemarkID = remarkCode;
            MermasSAP.Remark = remark;
            MermasSAP.UsuarioEncargado = usuario;
            MermasSAP.CuentaContable = cuentaContable;
            //MermasSAP.Remark = remark;

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
