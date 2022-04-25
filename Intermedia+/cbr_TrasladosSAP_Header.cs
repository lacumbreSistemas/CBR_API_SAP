namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_TrasladosSAP_Header
    {
        public int id { get; set; }

        public int? DocEntry { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(10)]
        public string Origen { get; set; }

        [StringLength(10)]
        public string Destino { get; set; }

        public int? code { get; set; }
    }
}
