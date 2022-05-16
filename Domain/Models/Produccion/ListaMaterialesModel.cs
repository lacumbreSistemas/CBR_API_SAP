using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
   public class ListaMaterialesModel
    {

        public string code { get; set; }

        public string descriptionReceta { get; set; }

        public List<ListaMaterialesEntryModel> materiales = new List<ListaMaterialesEntryModel>();


    }
}
