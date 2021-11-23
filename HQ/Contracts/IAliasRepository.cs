using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Contracts
{
   public interface IAliasRepository
    {
        int getItemId(string itemLookupCode);

    }
}
