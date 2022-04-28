using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
   public class OrdenProduccionRepo
    {

        public void generarOrdenProduccion() {
            OrdenProduccionSAP ordenProduccion = new OrdenProduccionSAP();
            ordenProduccion.generarOrdenProduccion();




        }
    }
}
