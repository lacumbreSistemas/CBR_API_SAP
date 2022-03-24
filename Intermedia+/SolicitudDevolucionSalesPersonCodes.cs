namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SolicitudDevolucionSalesPersonCodes
    {
        public int id { get; set; }

        public int? codigo { get; set; }

        [StringLength(3)]
        public string tienda { get; set; }
    }
}
