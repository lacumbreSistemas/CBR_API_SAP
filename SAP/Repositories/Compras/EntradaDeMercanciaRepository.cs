using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;


namespace SAP.Repositories.Compras
{
    public class EntradaDeMercanciaRepository 
    {

        MasterRepository masterRepo = MasterRepository.GetInstance();

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
            //masterRepo.connection.StartTransaction();
            int DocumentoAgregado = 0;
            string numeroNuevaEM = "";
          


            Documents DocumentoEntradaMercancia = masterRepo.connection.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);
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

                numeroNuevaEM = masterRepo.connection.GetNewObjectKey();
                return  Convert.ToInt32(numeroNuevaEM);
               
            }
            throw new Exception ("Entrada de mercancía Error [" + masterRepo.connection.GetLastErrorDescription() + "] ");


            //if (masterRepo.connection.InTransaction) 
            //{
            //    masterRepo.connection.EndTransaction(BoWfTransOpt.wf_Commit);
            //}

        }

        //obtiene la cantidad de escaneos que no están en entradas de mercancía, o que estén en entrada de mercancias canceladas.
        public double ObtenerCantidadesEscaneadas(int DocEntry,string itemCode)
        {
           var cantidadEscaneada =  masterRepo.doQuery(@"select isnull(sum(cantidad),0) as cantidad 
                                                        from  cbr_entradasMercanciaDeEscaneos
                                                        where OCDocEntry ="+DocEntry+ " and itemCode = '"+itemCode+ "' and (CANCELED = 'N' or entradaMercanciaDocEntry = 0) and devolucionBaseEntry is null");
            return cantidadEscaneada.Fields.Item("cantidad").Value;
        }


    }
}
