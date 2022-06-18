namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cbr_MapAlmacenesProduccion
    {
        public int id { get; set; }

        [StringLength(5)]
        public string almacenTienda { get; set; }

        [StringLength(5)]
        public string almacenProduccion { get; set; }
    }
}
