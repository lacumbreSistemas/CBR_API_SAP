namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_ComprasSAP_Entry
    {
        public int id { get; set; }

        public int? BaseLine { get; set; }

        public int? BaseEntry { get; set; }

        [StringLength(255)]
        public string ItemCode { get; set; }

        public double? Quantity { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }

        [StringLength(255)]
        public string normaReparto { get; set; }

        public DateTime? fecha { get; set; }

        public bool? ifSap { get; set; }

        public bool? deleted { get; set; }
    }
}
