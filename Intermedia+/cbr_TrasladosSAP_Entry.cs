namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_TrasladosSAP_Entry
    {
        public int id { get; set; }

        public int? DocEntry { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(255)]
        public string ItemCode { get; set; }

        public double? quantity { get; set; }

        [StringLength(255)]
        public string usuario { get; set; }

        [StringLength(10)]
        public string Origen { get; set; }

        [StringLength(10)]
        public string Destino { get; set; }

        public int? code { get; set; }

        public int? BaseLine { get; set; }

        public bool? ifSap { get; set; }

        public bool? deleted { get; set; }
    }
}
