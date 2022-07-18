using SAP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Repositories.Produccion
{
   public interface IListaMaterialesSAP
    {
         List<ListaMaterialEntity> obtenerListasMateriales();
   
    }
}
