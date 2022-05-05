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
            string centroCosto1 =mermasSAPEntity.CentroCosto;

            string centroCosto3 = mermasSAPEntity.CentroCosto3;
            


          


            Documents salidaMercancia = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oDrafts);
            salidaMercancia.Comments = mermasSAPEntity.Comentario;
            salidaMercancia.DocObjectCode = BoObjectTypes.oInventoryGenExit;
           

            salidaMercancia.UserFields.Fields.Item("U_remark").Value = mermasSAPEntity.RemarkID;
            salidaMercancia.UserFields.Fields.Item("U_encargado_dev").Value = mermasSAPEntity.UsuarioEncargado;
            salidaMercancia.UserFields.Fields.Item("U_Concep_Remark").Value = mermasSAPEntity.Remark;
            salidaMercancia.UserFields.Fields.Item("U_almdest").Value =tienda;
         
            
            mermasSAPEntity.mermasSAPEntryEntity.ForEach(i => {
                //costo promedio producto 
                var consultaCostoProducto = _MasterRepository.doQuery("Select avgprice from oitw where Whscode = '"+tienda+"' and itemcode = '"+i.ItemCode+"'");
              
                Document_Lines salidaMercanciaLines = salidaMercancia.Lines;
                salidaMercanciaLines.ItemCode = i.ItemCode;
                salidaMercanciaLines.Quantity = i.Cantidad;
                salidaMercanciaLines.AccountCode = mermasSAPEntity.CuentaContable;
                salidaMercanciaLines.WarehouseCode = tienda;
                salidaMercanciaLines.CostingCode = centroCosto1;
                salidaMercanciaLines.CostingCode3 = centroCosto3;

                if (consultaCostoProducto.RecordCount > 0)
                {
                    consultaCostoProducto.MoveFirst();
                    double costoProducto =  consultaCostoProducto.Fields.Item("avgprice").Value;
                    salidaMercanciaLines.UserFields.Fields.Item("U_costoproduc").Value = costoProducto.ToString() ;
                }
                else {

                    throw new Exception("No se encontó costo del producto");
                }
               
                
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


  

        public string obgenerCuentaContable(string code)
        {
            var consultaremark = _MasterRepository.doQuery(@"	select U_Cuenta_Contable from [@oREMARK] c
	                                                            inner join [@REMARK1] d on c.Code = d.Code
	                                                            where U_Codigo_Remark = '" + code + "'");
            consultaremark.MoveFirst();
            string remark = consultaremark.Fields.Item("U_Cuenta_Contable").Value;
            return remark;
        }

    }
}
