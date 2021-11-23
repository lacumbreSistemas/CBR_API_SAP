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

        public virtual DbSet<cbr_ComprasSAP_Entry> cbr_ComprasSAP_Entry { get; set; }
        public virtual DbSet<cbr_ComprasSAP_Header> cbr_ComprasSAP_Header { get; set; }
        public virtual DbSet<cbr_TrasladosSAP_Entry> cbr_TrasladosSAP_Entry { get; set; }
        public virtual DbSet<cbr_TrasladosSAP_Header> cbr_TrasladosSAP_Header { get; set; }
        public virtual DbSet<cbr_UsuariosApiSAP> cbr_UsuariosApiSAP { get; set; }
        public virtual DbSet<inventarioSAP> inventarioSAP { get; set; }
        public virtual DbSet<tiendas> tiendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cbr_ComprasSAP_Entry>()
                .Property(e => e.ItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ComprasSAP_Entry>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ComprasSAP_Entry>()
                .Property(e => e.normaReparto)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ComprasSAP_Header>()
                .Property(e => e.CardCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_TrasladosSAP_Entry>()
                .Property(e => e.ItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_TrasladosSAP_Entry>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_TrasladosSAP_Entry>()
                .Property(e => e.Origen)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_TrasladosSAP_Entry>()
                .Property(e => e.Destino)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_TrasladosSAP_Header>()
                .Property(e => e.Origen)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_TrasladosSAP_Header>()
                .Property(e => e.Destino)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_UsuariosApiSAP>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_UsuariosApiSAP>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_UsuariosApiSAP>()
                .Property(e => e.contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<inventarioSAP>()
                .Property(e => e.ItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<inventarioSAP>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tiendas>()
                .Property(e => e.WhsCode)
                .IsUnicode(false);
        }
    }
}
