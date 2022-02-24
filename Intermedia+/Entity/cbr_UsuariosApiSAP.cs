namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_UsuariosApiSAP
    {
        public int id { get; set; }

        [StringLength(255)]
        public string usuario { get; set; }

        [StringLength(500)]
        public string nombre { get; set; }

        [StringLength(1000)]
        public string contrasenia { get; set; }
    }
}
