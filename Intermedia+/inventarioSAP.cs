namespace Intermedia_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inventarioSAP")]
    public partial class inventarioSAP
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocEntry { get; set; }

        [StringLength(200)]
        public string ItemCode { get; set; }

        public DateTime? CountTime { get; set; }

        public double? CountQty { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }

        public bool? ifSAP { get; set; }

        public bool? deleted { get; set; }

        public int? deletedID { get; set; }
    }
}
