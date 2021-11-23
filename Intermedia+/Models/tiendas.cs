namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tiendas
    {
        public int id { get; set; }

        [StringLength(20)]
        public string WhsCode { get; set; }

        public bool? activa { get; set; }
    }
}
