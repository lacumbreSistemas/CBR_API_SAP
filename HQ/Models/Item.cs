namespace HQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [Required]
        [StringLength(20)]
        public string BinLocation { get; set; }

        [Column(TypeName = "money")]
        public decimal BuydownPrice { get; set; }

        public double BuydownQuantity { get; set; }

        [Column(TypeName = "money")]
        public decimal CommissionAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal CommissionMaximum { get; set; }

        public int CommissionMode { get; set; }

        public float CommissionPercentProfit { get; set; }

        public float CommissionPercentSale { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        public bool FoodStampable { get; set; }

        public int HQID { get; set; }

        public bool ItemNotDiscountable { get; set; }

        public DateTime? LastReceived { get; set; }

        public DateTime LastUpdated { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public double QuantityCommitted { get; set; }

        public int SerialNumberCount { get; set; }

        public double TareWeightPercent { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string ItemLookupCode { get; set; }

        public int DepartmentID { get; set; }

        public int CategoryID { get; set; }

        public int MessageID { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceA { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceB { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceC { get; set; }

        [Column(TypeName = "money")]
        public decimal SalePrice { get; set; }

        public DateTime? SaleStartDate { get; set; }

        public DateTime? SaleEndDate { get; set; }

        public int QuantityDiscountID { get; set; }

        public int TaxID { get; set; }

        public short ItemType { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public double Quantity { get; set; }

        public double ReorderPoint { get; set; }

        public double RestockLevel { get; set; }

        public double TareWeight { get; set; }

        public int SupplierID { get; set; }

        public int TagAlongItem { get; set; }

        public double TagAlongQuantity { get; set; }

        public int ParentItem { get; set; }

        public double ParentQuantity { get; set; }

        public short BarcodeFormat { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceLowerBound { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceUpperBound { get; set; }

        [Required]
        [StringLength(50)]
        public string PictureName { get; set; }

        public DateTime? LastSold { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string ExtendedDescription { get; set; }

        [Required]
        [StringLength(30)]
        public string SubDescription1 { get; set; }

        [Required]
        [StringLength(30)]
        public string SubDescription2 { get; set; }

        [Required]
        [StringLength(30)]
        public string SubDescription3 { get; set; }

        [Required]
        [StringLength(4)]
        public string UnitOfMeasure { get; set; }

        public int SubCategoryID { get; set; }

        public bool QuantityEntryNotAllowed { get; set; }

        public bool PriceMustBeEntered { get; set; }

        [Required]
        [StringLength(30)]
        public string BlockSalesReason { get; set; }

        public DateTime? BlockSalesAfterDate { get; set; }

        public double Weight { get; set; }

        public bool Taxable { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] DBTimeStamp { get; set; }

        public DateTime? BlockSalesBeforeDate { get; set; }

        [Column(TypeName = "money")]
        public decimal LastCost { get; set; }

        [Column(TypeName = "money")]
        public decimal ReplacementCost { get; set; }

        public bool WebItem { get; set; }

        public int BlockSalesType { get; set; }

        public int BlockSalesScheduleID { get; set; }

        public int SaleType { get; set; }

        public int SaleScheduleID { get; set; }

        public bool Consignment { get; set; }

        public bool Inactive { get; set; }

        public DateTime? LastCounted { get; set; }

        public bool DoNotOrder { get; set; }

        [Column(TypeName = "money")]
        public decimal MSRP { get; set; }

        public DateTime DateCreated { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string UsuallyShip { get; set; }

        public double? ScaleRMS { get; set; }
    }
}
