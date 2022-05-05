namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_ProduccionEntry
    {
        public int id { get; set; }

        [StringLength(50)]
        public string itemcode { get; set; }

        public double? quantity { get; set; }

        public DateTime? fecha { get; set; }

        public bool? deleted { get; set; }

        public int? deletedId { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }

        public int? numero { get; set; }

        public bool? cancelado { get; set; }
    }
}
