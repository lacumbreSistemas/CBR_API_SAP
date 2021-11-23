namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_ComprasSAP_Header
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CardCode { get; set; }

        public DateTime? fecha { get; set; }

        public int? BaseEntry { get; set; }

        public bool? ifSAP { get; set; }
    }
}
