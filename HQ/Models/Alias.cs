namespace HQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alias")]
    public partial class Alias
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        [Column("Alias")]
        [Required]
        [StringLength(25)]
        public string Alias1 { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] DBTimeStamp { get; set; }
    }
}
