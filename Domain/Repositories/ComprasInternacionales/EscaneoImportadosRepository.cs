using Domain.Models;
using Domain.Models.ComrpasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.ComprasInternacionales
{
    public class EscaneoImportadosRepository
    {

        EscaneoBuildInternacionalEstrategia estrategia;

        public EscaneoImportadosRepository()
        {

            estrategia = new EscaneoBuildInternacionalEstrategia();
        }



        public EscaneoBuildModel Agregar(EscaneoBuildModel escaneo)
        {

            EscaneoBuildModel Escaneo = new EscaneoBuildModel(escaneo, estrategia);
            return Escaneo.agreagar();

        }



    }

}
