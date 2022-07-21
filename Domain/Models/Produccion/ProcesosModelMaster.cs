﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProcesosModelMaster
    {
        public int numero { get; set; }
        public string codigoTienda { get; set; }

        public string usuario { get; set; }
        
        public string comentario { get; set; }

        public DateTime fechaCreacion { get; set; }

        public string codigoProducto { get; set; }

        public string remarkCode { get; set; }
        public string remark { get; set; }
        public double cantidad { get; set; }


        private bool IsEmpaque = false;



        public bool obtenerIsEmpaque()
        {

            return IsEmpaque;
        }

        public void establecerEmpaque(bool isEmpaque)
        {

            IsEmpaque = isEmpaque;
        }

    }
}
