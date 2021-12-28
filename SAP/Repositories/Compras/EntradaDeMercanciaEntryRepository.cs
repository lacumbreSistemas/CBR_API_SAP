using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Compras
{
  public   class EntradaDeMercanciaEntryRepository
    {
       private MasterRepository masterRepo = MasterRepository.GetInstance();


        public double ObtenerCantidadIngresada(int BaseEntry, string itemCode)
        {

            var recordSet = masterRepo.doQuery("select sum(Quantity) as quantity from pdn1 where BaseEntry =" + BaseEntry + " and itemCode = '" + itemCode + "'");

            return recordSet.Fields.Item("quantity").Value;
        }
    }
}
