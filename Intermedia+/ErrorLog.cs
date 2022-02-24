namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ErrorLog")]
    public partial class ErrorLog
    {
        public int id { get; set; }

        [StringLength(300)]
        public string mensaje { get; set; }

        [StringLength(60)]
        public string pathEndPoint { get; set; }

        public string detalle { get; set; }
    }
}
