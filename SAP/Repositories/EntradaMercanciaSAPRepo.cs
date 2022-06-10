using SAP.Models.Produccion;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories
{
    public class EntradaMercanciaSAPRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();

       


        public int generarEntradaMercancia(ProduccionSAPEntity produccionSAPEntity,int docEntrySalidaMercancia)
        {

            int siDocumentoAgregado = 0;
            string nuevasalidaMercancia = "";
            string tienda = produccionSAPEntity.WhsCode;
            string centroCosto1 = produccionSAPEntity.CentroCosto;

            string centroCosto3 = produccionSAPEntity.CentroCosto3;


            Documents salidaMercancia = _MasterRepository.connection.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
            salidaMercancia.Comments = produccionSAPEntity.Comentario;
       


            salidaMercancia.UserFields.Fields.Item("U_remark").Value = produccionSAPEntity.RemarkID;
            salidaMercancia.UserFields.Fields.Item("U_encargado_dev").Value = produccionSAPEntity.UsuarioEncargado;
            salidaMercancia.UserFields.Fields.Item("U_Con_Remark").Value = produccionSAPEntity.Remark;
            salidaMercancia.UserFields.Fields.Item("U_almdest").Value = tienda;
            salidaMercancia.UserFields.Fields.Item("U_Cant_Merma").Value = docEntrySalidaMercancia;

            produccionSAPEntity.produccionEntryEntrada.ForEach(i => {
                //costo promedio producto 
                var consultaCostoProducto = _MasterRepository.doQuery("Select avgprice from oitw where Whscode = '" + tienda + "' and itemcode = '" + i.ItemCode + "'");

                Document_Lines salidaMercanciaLines = salidaMercancia.Lines;
                salidaMercanciaLines.ItemCode = i.ItemCode;
                salidaMercanciaLines.Quantity = i.Cantidad;
                salidaMercanciaLines.AccountCode = produccionSAPEntity.CuentaContable;
                salidaMercanciaLines.WarehouseCode = tienda;
                salidaMercanciaLines.CostingCode = centroCosto1;
                salidaMercanciaLines.CostingCode3 = centroCosto3;
                salidaMercanciaLines.UnitPrice = (double) i.costoLibra;
                //salidaMercanciaLines.UserFields.Fields.Item("U_costoproduc").Value = (double)i.costoLibra; 
                //if (consultaCostoProducto.RecordCount > 0)
                //{
                //    consultaCostoProducto.MoveFirst();
                //    double costoProducto = consultaCostoProducto.Fields.Item("avgprice").Value;
                //    salidaMercanciaLines.UserFields.Fields.Item("U_costoproduc").Value = costoProducto.ToString();
                //}
                //else
                //{

                //    throw new Exception("No se encontó costo del producto");
                //}


                salidaMercanciaLines.Add();
            });

            siDocumentoAgregado = salidaMercancia.Add();


            if (siDocumentoAgregado == 0)
            {

                nuevasalidaMercancia = _MasterRepository.connection.GetNewObjectKey();
                return Convert.ToInt32(nuevasalidaMercancia);

            }
            throw new Exception("Error entrada mercancía [" + _MasterRepository.connection.GetLastErrorDescription() + "] ");

        }


    }
}
