using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
    public class PurchaseOrderHeader
    {

        public int docEntry { get; set; }
        public DateTime taxDate { get; set; }

        public int docNum { get; set; }
        public string cardCode { get; set; }

        public DateTime docDueDate { get; set; }
        public string cardName { get; set; }

        public PurchaseOrderHeader() { }
        public PurchaseOrderHeader(int docEntry, DateTime taxDate, int docNum, string cardCod, DateTime docDueDate, string cardName)
        {
            this.docEntry = docEntry;
            this.taxDate = taxDate;
            this.docNum = docNum;
            this.cardCode = cardCod;
            this.docDueDate = docDueDate;
            this.cardName = cardName;
        }
    }
}
