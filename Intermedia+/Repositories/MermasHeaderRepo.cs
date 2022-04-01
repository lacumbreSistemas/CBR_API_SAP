using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
  public  class MermasHeaderRepo:MasterRespository
    {

        public cbr_MermasHeader crearDocumentoIntermedioMerma(cbr_MermasHeader merma) {

            db.cbr_MermasHeader.Add(merma);
            db.SaveChanges();


            return merma;
        
        }
    }
}
