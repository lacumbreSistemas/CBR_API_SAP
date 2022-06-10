using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
   public class cbr_contenedoresInternacionalesCerradosRepo:MasterRespository
    {
        public List<cbr_contenedoresInternacionalesCerradosRepo> obtenerContenedoresCerrados() {

            List<cbr_contenedoresInternacionalesCerradosRepo> contenedores = new List<cbr_contenedoresInternacionalesCerradosRepo>();

            

            return contenedores;
        }


        public bool siContenedorCerrado(string numeroContenedor) {

            return db.cbr_contenedoresInternacionalesCerrados.FirstOrDefault(i=> i.numeroContenedor == numeroContenedor) != null;
        }
    }
}
