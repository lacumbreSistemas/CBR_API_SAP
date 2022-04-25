using SAP.Models;
using SAP.Models.Mermas;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
   public class MermasSAPRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();


        public int generarMerma(MermasSAPEntity mermasSAPEntity) {

            int siDocumentoAgregado = 0;
            string nuevasalidaMercancia = "";
            string tienda = mermasSAPEntity.WhsCode;

        Documents salidaMercancia = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oDrafts);
            salidaMercancia.Comments = mermasSAPEntity.Comentario;
            salidaMercancia.JournalMemo = mermasSAPEntity.JournalMemo;
            salidaMercancia.DocObjectCode = BoObjectTypes.oInventoryGenExit;
            salidaMercancia.UserFields.Fields.Item("U_remark").Value = mermasSAPEntity.Remark;

            mermasSAPEntity.mermasSAPEntryEntity.ForEach(i => {

                Document_Lines salidaMercanciaLines = salidaMercancia.Lines;
                salidaMercanciaLines.ItemCode = i.ItemCode;
                salidaMercanciaLines.Quantity = i.Cantidad;
                salidaMercanciaLines.WarehouseCode = tienda;
                salidaMercanciaLines.Add();
            });
         
            siDocumentoAgregado = salidaMercancia.Add();
           

            if (siDocumentoAgregado == 0)
            {

                nuevasalidaMercancia = _MasterRepository.connection.GetNewObjectKey();
                return Convert.ToInt32(nuevasalidaMercancia);

            }
            throw new Exception("Salida mercancía Error [" + _MasterRepository.connection.GetLastErrorDescription() + "] ");

        }


        public List<Remarks> obtenerRemarks() {
          List<Remarks> remarks = new List<Remarks>();
          var remarksSAP =   _MasterRepository.doQuery("select code,U_Remark from [@REMARK1]");

            while (!remarksSAP.EoF) {
                Remarks remark = new Remarks();

                remark.code = remarksSAP.Fields.Item("code").Value;
                remark.remark = remarksSAP.Fields.Item("U_Remark").Value;

                remarks.Add(remark);
                remarksSAP.MoveNext();
            }
            return remarks; 
        }


    }
}
