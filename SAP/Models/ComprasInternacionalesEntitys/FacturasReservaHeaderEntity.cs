using SAP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.ComprasInternacionalesEntitys
{
    public class FacturasReservaHeaderEntity: IOCHeader
    {
        public int docEntry { get; set; }
        public DateTime taxDate { get; set; }

        public int docNum { get; set; }
        public string cardCode { get; set; }

        public DateTime docDueDate { get; set; }
        public string cardName { get; set; }


    }




    
}
