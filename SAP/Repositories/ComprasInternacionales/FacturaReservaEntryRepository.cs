using SAP.Models;
using SAP.Models.ComprasInternacionalesEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.ComprasInternacionales
{
    public class FacturaReservaEntryRepository : MasterRepository
    {

        public FacturaReservaEntryRepository(){
            
            

        }


        public List<FacturasReservaEntryEntity> ObtenerListaDeEntriesFacturaReserva(int? docEntry)
        {
            doQuery(@"select  E.ItemCode as codigoProducto,
                              i.ItemName as nombreProducto,
                              E.Quantity as cantidadOrdenada,
                              E.DocEntry as docEntry,
                              E.Baseline as Baseline,
                              E.OcrCode  as NormaReparto
                        FROM PCH1 E
                     inner join OITM i on i.ItemCode = E.ItemCode
                    where  E.DocEntry =" + docEntry);

            List<FacturasReservaEntryEntity> facturasReservas = new List<FacturasReservaEntryEntity>();



            while (!recordSet.EoF) {
                FacturasReservaEntryEntity FR = new FacturasReservaEntryEntity();

                FR.docEntry = recordSet.Fields.Item("docEntry").Value;
                FR.nombreProducto = recordSet.Fields.Item("nombreProducto").Value;
                FR.codigoProducto = recordSet.Fields.Item("codigoProducto").Value;
                FR.cantidadOrdenada = recordSet.Fields.Item("cantidadOrdenada").Value;
                FR.baseLine = recordSet.Fields.Item("Baseline").Value;
                FR.normaReparto = recordSet.Fields.Item("NormaReparto").Value;


                facturasReservas.Add(FR);
                recordSet.MoveNext();
            }

            return facturasReservas;


        }

        public FacturasReservaEntryEntity ObtenerEntrieDeFacturaReserva(int? docEntry, string itemCode)
        {

            doQuery(@"select                E.ItemCode as codigoProducto,
                                            i.ItemName as nombreProducto,
                                            E.Quantity as cantidadOrdenada,
                                            E.DocEntry as docEntry,
                                            E.Baseline as Baseline,
                                            E.OcrCode  as NormaReparto
                                        FROM PCH1 E
                                        inner join OITM i on i.ItemCode = E.ItemCode
                     where  E.DocEntry = " + docEntry + "and E.itemCode = '" + itemCode + "'");
                                FacturasReservaEntryEntity FR = new FacturasReservaEntryEntity();

                                FR.docEntry = recordSet.Fields.Item("docEntry").Value;
                                FR.nombreProducto = recordSet.Fields.Item("nombreProducto").Value;
                                FR.codigoProducto = recordSet.Fields.Item("codigoProducto").Value;
                                FR.cantidadOrdenada = recordSet.Fields.Item("cantidadOrdenada").Value;
                                FR.baseLine = recordSet.Fields.Item("Baseline").Value;
                                FR.normaReparto = recordSet.Fields.Item("NormaReparto").Value;

            return FR;

        }

        public double ObtenerCantidadOrdenada(int? docEntry, string itemCode)
        {

            doQuery("select quantity from PCH1 where docentry = " + docEntry + " and itemCode = '" + itemCode + "'");

            double cantidadOrdenada = recordSet.Fields.Item("Quantity").Value;

            if (cantidadOrdenada == 0 || cantidadOrdenada == null)
                throw new Exception("Item no existe en orden de compra");

            return cantidadOrdenada;
        }

        public int obtenerLineNum(int? docEntry, string itemCode)
        {
            //Conectar();
            doQuery("select LineNum from Por1 where docentry = " + docEntry + " and itemCode = '" + itemCode + "'");
            return recordSet.Fields.Item("LineNum").Value;
        }

    }
}
