namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_SolicitudDevolucionHeader
    {
        public int id { get; set; }

        public int number { get; set; }

        [StringLength(5)]
        public string whsCode { get; set; }

        [StringLength(30)]
        public string cardCode { get; set; }

        public DateTime? fecha { get; set; }

        public int docEntry { get; set; }

        public bool anulado { get; set; }

        [StringLength(800)]
        public string comentario { get; set; }
    }
}
