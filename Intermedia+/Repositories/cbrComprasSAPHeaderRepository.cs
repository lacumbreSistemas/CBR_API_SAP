using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbrComprasSAPHeaderRepository: MasterRespository
    {
        

        public cbr_ComprasSAP_Header Get(int DocEntry) {


           cbr_ComprasSAP_Header Header =  db.cbr_ComprasSAP_Header.FirstOrDefault(i=> i.BaseEntry == DocEntry); 

            return Header;
            
        }


        public bool ifExist(int DocEntry) {

            var Header = Get(DocEntry);

            return Header != null;

        }


        public void Post(cbr_ComprasSAP_Header header) {

            db.cbr_ComprasSAP_Header.Add(header);
            db.SaveChanges();
            
        }


      
    }
}
