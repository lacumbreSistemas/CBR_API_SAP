namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_ComprasSAP_Escaneo
    {
        public int id { get; set; }

        public int baseEntry { get; set; }

        [StringLength(255)]
        public string itemCode { get; set; }

        [StringLength(50)]
        public string nombreUsuario { get; set; }

        public double cantidad { get; set; }

        public DateTime? fecha { get; set; }

        public int entradaMercanciaDocEntry { get; set; }

        public int baseLine { get; set; }

        public bool deleted { get; set; }

        public int escaneoAnuladoID { get; set; }

        public bool matriculado { get; set; }
    }
}
