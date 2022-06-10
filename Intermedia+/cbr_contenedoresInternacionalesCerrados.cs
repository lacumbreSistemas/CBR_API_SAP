namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_contenedoresInternacionalesCerrados
    {
        public int id { get; set; }

        [StringLength(255)]
        public string numeroContenedor { get; set; }

        [StringLength(40)]
        public string usuario { get; set; }

        public DateTime? fecha { get; set; }
    }
}
