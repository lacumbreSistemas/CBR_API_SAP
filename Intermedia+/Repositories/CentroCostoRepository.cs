using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class CentroCostoRepository:MasterRespository
    {
        public string obtenerCentroCostoTienda(string WhsCode)
        {
            var centroCostoTienda = db.centroCostoMap.FirstOrDefault(i=> i.WhsCode == WhsCode);

            return  centroCostoTienda.CentroCosto == null ? throw new Exception("no hay centro de costo registrado para esta tienda"): centroCostoTienda.CentroCosto;

        }
    }
}
