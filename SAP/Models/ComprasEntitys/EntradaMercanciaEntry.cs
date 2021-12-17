using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models
{
   public class EntradaMercanciaEntry
    {
      public int BaseType { get; set; }
      public int BaseEntry { get; set; }
      public string  ItemCode { get; set; }
      public double Quantity { get; set; }
      public int BaseLine { get; set; }


        public EntradaMercanciaEntry() { 
        
        }


    }
}
