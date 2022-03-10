using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryModelMaster
    {
        public string? itemCode { get; set; }
        public double? cantidad { get; set; }
        public DateTime? fecha { get; set; }
        public bool? deleted { get; set; }
        public int? deletedId { get; set; }
        public string? usuario { get; set; }
        public int? numero { get; set; }

    }
}
