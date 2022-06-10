namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("centroCostoMap")]
    public partial class centroCostoMap
    {
        [StringLength(7)]
        public string WhsCode { get; set; }

        [StringLength(8)]
        public string CentroCosto { get; set; }

        public int id { get; set; }
    }
}
