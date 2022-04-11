using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.Mermas
{
    public class MermasSAPEntity
    {
        public int DocEntry { get; set; }
        public string WhsCode { get; set; }
        public string Comentario { get; set; }
        public string JournalMemo { get; set; }

        public DateTime Fecha { get; set; }

        public List<MermasSAPEntryEntity> mermasSAPEntryEntity { get; set; }

    

       public MermasSAPEntity()
        {
            mermasSAPEntryEntity = new List<MermasSAPEntryEntity>();
        }




        // JournalMemo

    }
}
