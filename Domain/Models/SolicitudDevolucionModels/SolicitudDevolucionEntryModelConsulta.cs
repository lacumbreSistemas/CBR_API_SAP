using Intermedia_.Repositories;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryModelConsulta: SolicitudDevolucionEntryModelMaster 
    {
        public int? id { get; set; }

    
        public SolicitudDevolucionEntryModelConsulta() {
            
        }


        public void anular() { 
        
        
        }

      
    }
}
