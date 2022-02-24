using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace HQ
{
    public partial class HQEF : DbContext
    {
        public HQEF()
            : base(ConfigurationManager.ConnectionStrings["HQEF"].ToString())
        {
        }

        public virtual DbSet<Alias> Alias { get; set; }
        public virtual DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alias>()
                .Property(e => e.DBTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.BuydownPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.CommissionAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.CommissionMaximum)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.PriceA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.PriceB)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.PriceC)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.PriceLowerBound)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.PriceUpperBound)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.DBTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.LastCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.ReplacementCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.MSRP)
                .HasPrecision(19, 4);
        }
    }
}
