using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;


namespace SAP.Repositories.Compras
{
    public class EntradaDeMercanciaRepository:MasterRepository 
    {


        public int  GenerarEntradaMercancia(EntradaDeMercancia EM) {

            return GenerarEM(EM, BoObjectTypes.oPurchaseOrders);
        }

        public int GenerarEntradaMercanciaImportados(EntradaDeMercancia EM)
        {

            return GenerarEM(EM, BoObjectTypes.oPurchaseInvoices);
        }
        //oPurchaseInvoices

        public int GenerarEM(EntradaDeMercancia EM, BoObjectTypes objectoBase)
        {
            int DocumentoAgregado = 0;
            string numeroNuevaEM = "";
          

            Conectar();

            Documents DocumentoEntradaMercancia = connection.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);
            DocumentoEntradaMercancia.CardCode = EM.CardCode;

            EM.Entries.ForEach(i => {

                Document_Lines entryEntradaMercancia = DocumentoEntradaMercancia.Lines;

                entryEntradaMercancia.BaseType = (int)objectoBase;
                entryEntradaMercancia.BaseEntry = i.BaseEntry;
                entryEntradaMercancia.ItemCode = i.ItemCode;
                entryEntradaMercancia.Quantity = i.Quantity;
                entryEntradaMercancia.BaseLine = i.BaseLine;


                //entryEntradaMercancia.BatchNumbers.BatchNumber = "1";
                //entryEntradaMercancia.BatchNumbers.Quantity = i.Quantity;
                //entryEntradaMercancia.BatchNumbers.Add();
                entryEntradaMercancia.Add();
            });
            DocumentoAgregado = DocumentoEntradaMercancia.Add();
           

            if (DocumentoAgregado == 0)
            {

                numeroNuevaEM = connection.GetNewObjectKey();
                Desconectar();
                return  Convert.ToInt32(numeroNuevaEM);
               
            }
            throw new Exception ("Entrada de mercancía [" + connection.GetLastErrorDescription() + "] creada!");


        }



       
    }
}
