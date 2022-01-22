using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Intermedia_
{
    public partial class Data : DbContext
    {
        public Data()
            : base("data source=10.10.1.12;initial catalog=ApiSAP;persist security info=True;user id=sa;password=SAP#Sql_;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<cbr_ComprasSAP_Escaneo> cbr_ComprasSAP_Escaneo { get; set; }
        public virtual DbSet<cbr_listaItemsRecepcionImportados> cbr_listaItemsRecepcionImportados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cbr_ComprasSAP_Escaneo>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ComprasSAP_Escaneo>()
                .Property(e => e.nombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_listaItemsRecepcionImportados>()
                .Property(e => e.usuario)
                .IsUnicode(false);

          
            modelBuilder.Entity<cbr_listaItemsRecepcionImportados>()
                .Property(e => e.numeroContenedor)
                .IsUnicode(false);
        }
    }
}
