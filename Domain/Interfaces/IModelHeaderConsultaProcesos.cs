using Domain.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IModelHeaderConsultaProcesos
    {

        public ProcesosModelConsulta obtenerHeader(int numero);

        List<ProduccionEntryResumenConsulta> resumenEntries(int numero);
    }
}
