namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SolicitudDevolisionEscaneos
    {
        public int id { get; set; }

        [StringLength(40)]
        public string itemCode { get; set; }

        public double? cantidad { get; set; }

        public DateTime? fecha { get; set; }

        public bool? borrado { get; set; }

        public int? borradoId { get; set; }

        [StringLength(30)]
        public string usuario { get; set; }
    }
}
