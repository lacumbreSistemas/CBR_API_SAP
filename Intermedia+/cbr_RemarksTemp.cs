namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_RemarksTemp
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}
