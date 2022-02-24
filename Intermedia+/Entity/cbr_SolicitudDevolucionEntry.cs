namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_SolicitudDevolucionEntry
    {
        public int id { get; set; }

        [StringLength(50)]
        public string itemCode { get; set; }

        public double? quantity { get; set; }

        public DateTime? fecha { get; set; }

        public bool? deleted { get; set; }

        public int? deletedId { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }
    }
}
