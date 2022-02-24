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

            var recordSet = masterRepo.doQuery(@"select sum(e.Quantity) as quantity from pdn1 e
                                                 inner join opdn c on c.docentry = e.docentry
												 LEFT join prr1 dev on dev.BaseEntry = e.DocEntry and dev.ItemCode = e.ItemCode 
                                                where e.BaseEntry =" + BaseEntry + " and e.itemCode = '" + itemCode + "' and c.Canceled = 'N' and dev.DocEntry is null");
                
            return recordSet.Fields.Item("quantity").Value;
        }
    }
}
