using SAP.Models.Mermas;
using SAP.Models.Produccion;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
    public class SalidaMercanciaSAPRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();


        public int generarSalidaMercancia(ProduccionSAPEntity produccionSAPEntity)
        {

            int siDocumentoAgregado = 0;
            string nuevasalidaMercancia = "";
            string tienda = produccionSAPEntity.WhsCode;
            string centroCosto1 = produccionSAPEntity.CentroCosto;

            string centroCosto3 = produccionSAPEntity.CentroCosto3;






            Documents salidaMercancia = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
            salidaMercancia.Comments = produccionSAPEntity.Comentario;
            //salidaMercancia.DocObjectCode = BoObjectTypes.oInventoryGenExit;


            salidaMercancia.UserFields.Fields.Item("U_remark").Value = produccionSAPEntity.RemarkID;
            salidaMercancia.UserFields.Fields.Item("U_encargado_dev").Value = produccionSAPEntity.UsuarioEncargado;
            salidaMercancia.UserFields.Fields.Item("U_Con_Remark").Value = produccionSAPEntity.Remark;
            salidaMercancia.UserFields.Fields.Item("U_almdest").Value = tienda;

            #region entry produccion

 
                //costo promedio producto 
                var consultaCostoProducto = _MasterRepository.doQuery("Select avgprice from oitw where Whscode = '" + tienda + "' and itemcode = '" + produccionSAPEntity.itemCode + "'");

                Document_Lines salidaMercanciaLines = salidaMercancia.Lines;
                salidaMercanciaLines.ItemCode = produccionSAPEntity.itemCode;
                salidaMercanciaLines.Quantity = produccionSAPEntity.quantity;
                salidaMercanciaLines.AccountCode = produccionSAPEntity.CuentaContable;
                salidaMercanciaLines.WarehouseCode = tienda;
                salidaMercanciaLines.CostingCode = centroCosto1;
                salidaMercanciaLines.CostingCode3 = centroCosto3;

                if (consultaCostoProducto.RecordCount > 0)
                {
                    consultaCostoProducto.MoveFirst();
                    double costoProducto = consultaCostoProducto.Fields.Item("avgprice").Value;
                    salidaMercanciaLines.UserFields.Fields.Item("U_costoproduc").Value = costoProducto.ToString();
                salidaMercanciaLines.UnitPrice = costoProducto;
                }
                else
                {

                    throw new Exception("No se encontó costo del producto");
                }


                salidaMercanciaLines.Add();
       

            #endregion

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


        public decimal obtenerCostoPonderado(string tienda, string itemCode) {

            var consultaCostoProducto = _MasterRepository.doQuery("Select avgprice from oitw where Whscode = '" + tienda + "' and itemcode = '" + itemCode + "'");
            consultaCostoProducto.MoveFirst();
            decimal costoPonderado = 0;

            if (consultaCostoProducto.RecordCount > 0)
             costoPonderado = (decimal) consultaCostoProducto.Fields.Item("avgprice").Value;


            return costoPonderado;
        }

    }
}
