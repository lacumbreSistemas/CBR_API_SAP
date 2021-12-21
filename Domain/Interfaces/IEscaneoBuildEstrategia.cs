using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEscaneoBuildEstrategia
    {
        double ObtenerCantidadOrdenada(int? docEntry, string itemCode);
        int obtenerLineNum(int? docEntry, string itemCode);

    }
}
