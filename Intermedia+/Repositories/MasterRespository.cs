using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public abstract class MasterRespository 
    {


     public   Data db;

        public MasterRespository() {

            db = new Data();
        }



    }
}
