using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Intermedia_
{
    public partial class Data : DbContext
    {
        public Data()
            : base("data source=10.10.1.12;initial catalog=ApiSAPTest;persist security info=True;user id=sa;password=SAP#Sql_;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<cbr_ComprasSAP_Escaneo> cbr_ComprasSAP_Escaneo { get; set; }
        public virtual DbSet<cbr_contenedoresInternacionalesCerrados> cbr_contenedoresInternacionalesCerrados { get; set; }
        public virtual DbSet<cbr_SolicitudDevolucionEntry> cbr_SolicitudDevolucionEntry { get; set; }
        public virtual DbSet<cbr_SolicitudDevolucionHeader> cbr_SolicitudDevolucionHeader { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<SolicitudDevolisionEscaneos> SolicitudDevolisionEscaneos { get; set; }
        public virtual DbSet<cbr_listaItemsRecepcionImportados> cbr_listaItemsRecepcionImportados { get; set; }
        public virtual DbSet<cbr_UsuariosApiSAP> cbr_UsuariosApiSAP { get; set; }
        public virtual DbSet<inventarioSAP> inventarioSAP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cbr_ComprasSAP_Escaneo>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ComprasSAP_Escaneo>()
                .Property(e => e.nombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_contenedoresInternacionalesCerrados>()
                .Property(e => e.numeroContenedor)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_contenedoresInternacionalesCerrados>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionEntry>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionEntry>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            //modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
            //    .Property(e => e.number)
            //    .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
                .Property(e => e.whsCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
                .Property(e => e.cardCode)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.mensaje)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.pathEndPoint)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.detalle)
                .IsUnicode(false);

            modelBuilder.Entity<SolicitudDevolisionEscaneos>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<SolicitudDevolisionEscaneos>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_listaItemsRecepcionImportados>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_listaItemsRecepcionImportados>()
                .Property(e => e.numeroContenedor)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_listaItemsRecepcionImportados>()
                .Property(e => e.itemCode)
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
        }
    }
}
