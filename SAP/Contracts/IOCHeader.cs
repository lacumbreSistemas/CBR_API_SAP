using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Contracts
{
    interface IOCHeader
    {
         int docEntry { get; set; }
         DateTime taxDate { get; set; }

         int docNum { get; set; }
         string cardCode { get; set; }

         DateTime docDueDate { get; set; }
         string cardName { get; set; }

    }
}
