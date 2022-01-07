using SAP.Models.ComprasInternacionalesEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.ComprasInternacionalesContenedor
{
   public  class ComprasInternacionalesListaContenedorEntryRepository:MasterRepository
    {
        MasterRepository masterRepo = MasterRepository.GetInstance();
        public FacturasReservaEntryEntity obtenerItemPorNumeroContenedor(string numeroContenedor, string itemCode) {

            var recordSet = masterRepo.doQuery(@"select                E.ItemCode as codigoProducto,
                                            i.ItemName as nombreProducto,
                                            E.Quantity as cantidadOrdenada,
                                            E.DocEntry as docEntry,
                                            E.Baseline as Baseline,
                                            E.OcrCode  as NormaReparto
                                        FROM PCH1 E
                                        inner join OPCH C  on C.DocEntry = E.DocEntry
                     where  C.Comments = '" + numeroContenedor + "' and E.itemCode = '" + itemCode + "'");
            FacturasReservaEntryEntity FR = new FacturasReservaEntryEntity();

            FR.docEntry = recordSet.Fields.Item("docEntry").Value;
            FR.nombreProducto = recordSet.Fields.Item("nombreProducto").Value;
            FR.codigoProducto = recordSet.Fields.Item("codigoProducto").Value;
            FR.cantidadOrdenada = recordSet.Fields.Item("cantidadOrdenada").Value;
            FR.baseLine = recordSet.Fields.Item("Baseline").Value;
            FR.normaReparto = recordSet.Fields.Item("NormaReparto").Value;

            return FR;

        }


        public List<FacturasReservaEntryEntity> ObtenerListaDeEntriesPorNumeroContenedor(string NumeroContenedor)
        {
            var recordSet = masterRepo.doQuery(@"select  E.ItemCode as codigoProducto,
                              i.ItemName as nombreProducto,
                              E.Quantity as cantidadOrdenada,
                              E.DocEntry as docEntry,
                              E.Baseline as Baseline,
                         FROM PCH1 E
                                        inner join OPCH C  on C.DocEntry = E.DocEntry
                    where  C.Comments ='" + NumeroContenedor + "'");

            List<FacturasReservaEntryEntity> facturasReservas = new List<FacturasReservaEntryEntity>();



            while (!recordSet.EoF)
            {
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



   

    }
}
