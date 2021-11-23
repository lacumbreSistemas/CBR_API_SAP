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

        [StringLength(50)]
        public string usuario { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(200)]
        public string contrasenia { get; set; }
    }
}
