namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_MermasHeader
    {
        [Key]
        public int number { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(40)]
        public string cardCode { get; set; }

        [StringLength(2)]
        public string whsCode { get; set; }

        public int? docEntry { get; set; }

        public bool? anulado { get; set; }

        [StringLength(800)]
        public string comentario { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }
    }
}
