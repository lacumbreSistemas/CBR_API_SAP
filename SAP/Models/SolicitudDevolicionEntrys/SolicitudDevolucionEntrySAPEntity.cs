using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.SolicitudDevolicionEntrys
{
    public class SolicitudDevolucionEntrySAPEntity
    {
        public string ItemCode { get; set;}
        public double Cantidad { get; set;}
        public string NombreArticulo { get; set; }
    }
}
