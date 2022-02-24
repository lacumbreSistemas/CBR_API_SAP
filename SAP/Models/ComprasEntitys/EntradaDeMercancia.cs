using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace SAP.Models
{
    public class EntradaDeMercancia
    {
        public string CardCode { get; set; }
        public List<EntradaMercanciaEntry> Entries {get; set;}


        public EntradaDeMercancia() {
        Entries = new List<EntradaMercanciaEntry>();
           
        }

       
    }
}
