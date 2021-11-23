using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ
{
   public abstract class MasterRepository
    {
        public readonly HQEF data;
       public  MasterRepository()
        {
            data = new HQEF();
        }

    }
}
