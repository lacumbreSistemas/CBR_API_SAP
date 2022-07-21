using SAP.Models;
using SAP.Models.Produccion;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Transformaciones
{
    public class SalidaMercanciaTransformacionSAPRepo
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


            produccionSAPEntity.produccionEntryEntrada.ForEach(i=> {

                var consultaCostoProducto = _MasterRepository.doQuery("Select avgprice from oitw where Whscode = '" + tienda + "' and itemcode = '" + produccionSAPEntity.itemCode + "'");

                Document_Lines salidaMercanciaLines = salidaMercancia.Lines;
                salidaMercanciaLines.ItemCode = produccionSAPEntity.itemCode;
                salidaMercanciaLines.Quantity = produccionSAPEntity.quantity;
                salidaMercanciaLines.AccountCode = produccionSAPEntity.CuentaContable;
                salidaMercanciaLines.WarehouseCode = tienda;
                salidaMercanciaLines.CostingCode = centroCosto1;
                salidaMercanciaLines.CostingCode3 = centroCosto3;


                consultaCostoProducto.MoveFirst();
                salidaMercanciaLines.UserFields.Fields.Item("U_costoproduc").Value = produccionSAPEntity.costoPonderado.ToString();
                salidaMercanciaLines.UnitPrice = produccionSAPEntity.costoPonderado;


                salidaMercanciaLines.Add();


            });

           


            


            #endregion

            siDocumentoAgregado = salidaMercancia.Add();


            if (siDocumentoAgregado == 0)
            {

                nuevasalidaMercancia = _MasterRepository.connection.GetNewObjectKey();
                return Convert.ToInt32(nuevasalidaMercancia);

            }
            throw new Exception("Salida mercancía Error [" + _MasterRepository.connection.GetLastErrorDescription() + "] ");

        }

        public List<ItemSAP> ListaEmpaques() {


            var recordSet = _MasterRepository.doQuery("select ItemCode, ItemName from Oitm where FrgnName = 'UT'");
            List<ItemSAP> empaques = new List<ItemSAP>();


            while (!recordSet.EoF)
            {
                ItemSAP Item = new ItemSAP();
                Item.ItemCode = recordSet.Fields.Item("ItemCode").Value;
                Item.ItemName = recordSet.Fields.Item("ItemName").Value;
                empaques.Add(Item);
                recordSet.MoveNext();
            }

            return recordSet.RecordCount == 0 ? null : empaques;


        }

    }
}
