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

        //[StringLength(12)]
        public int number { get; set; }

        [StringLength(5)]
        public string whsCode { get; set; }

        [StringLength(30)]
        public string cardCode { get; set; }

        public DateTime? fecha { get; set; }
    }
}
