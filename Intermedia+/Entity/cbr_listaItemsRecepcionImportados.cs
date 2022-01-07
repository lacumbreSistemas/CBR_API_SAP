namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_listaItemsRecepcionImportados
    {
        public int id { get; set; }

        public double cantidad { get; set; }

        [StringLength(255)]
        public string usuario { get; set; }


        public DateTime fecha { get; set; }

        public bool deleted { get; set; }

        public int deletedId { get; set; }

        [StringLength(255)]
        public string numeroContenedor { get; set; }
        public string itemCode { get; set; }
    }
}
