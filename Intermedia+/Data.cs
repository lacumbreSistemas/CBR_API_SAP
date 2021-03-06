using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Intermedia_
{
    public partial class Data : DbContext
    {
        public Data()
#if (Pruebas)
            : base("data source=10.10.1.12;initial catalog=ApiSAPTest;persist security info=True;user id=sa;password=SAP#Sql_;MultipleActiveResultSets=True;App=EntityFramework")
#endif
#if (Debug)
            : base("data source=10.10.1.12;initial catalog=ApiSAPTest;persist security info=True;user id=sa;password=SAP#Sql_;MultipleActiveResultSets=True;App=EntityFramework")
#endif
#if (Produccion)
            : base("data source=10.10.1.12;initial catalog=ApiSAP;persist security info=True;user id=sa;password=SAP#Sql_;MultipleActiveResultSets=True;App=EntityFramework")
#endif
#if (Release)
            : base("data source=10.10.1.12;initial catalog=ApiSAPTest;persist security info=True;user id=sa;password=SAP#Sql_;MultipleActiveResultSets=True;App=EntityFramework")
#endif
        {
        }

        public virtual DbSet<cbr_ComprasSAP_Escaneo> cbr_ComprasSAP_Escaneo { get; set; }
        public virtual DbSet<cbr_contenedoresInternacionalesCerrados> cbr_contenedoresInternacionalesCerrados { get; set; }
        public virtual DbSet<cbr_MermasEntry> cbr_MermasEntry { get; set; }
        public virtual DbSet<cbr_MermasHeader> cbr_MermasHeader { get; set; }
        public virtual DbSet<cbr_ProduccionEntry> cbr_ProduccionEntry { get; set; }
        public virtual DbSet<cbr_ProduccionHeader> cbr_ProduccionHeader { get; set; }
        public virtual DbSet<cbr_RemarksTemp> cbr_RemarksTemp { get; set; }
        public virtual DbSet<cbr_SolicitudDevolucionEntry> cbr_SolicitudDevolucionEntry { get; set; }
        public virtual DbSet<cbr_SolicitudDevolucionHeader> cbr_SolicitudDevolucionHeader { get; set; }
        public virtual DbSet<centroCostoMap> centroCostoMap { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<SolicitudDevolisionEscaneos> SolicitudDevolisionEscaneos { get; set; }
        public virtual DbSet<cbr_listaItemsRecepcionImportados> cbr_listaItemsRecepcionImportados { get; set; }
        public virtual DbSet<cbr_MapAlmacenesProduccion> cbr_MapAlmacenesProduccion { get; set; }
        public virtual DbSet<cbr_TrasladosSAP_Entry> cbr_TrasladosSAP_Entry { get; set; }
        public virtual DbSet<cbr_TrasladosSAP_Header> cbr_TrasladosSAP_Header { get; set; }
        public virtual DbSet<cbr_UsuariosApiSAP> cbr_UsuariosApiSAP { get; set; }
        public virtual DbSet<inventarioSAP> inventarioSAP { get; set; }
        public virtual DbSet<SolicitudDevolucionSalesPersonCodes> SolicitudDevolucionSalesPersonCodes { get; set; }

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

            modelBuilder.Entity<cbr_MermasEntry>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_MermasEntry>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_MermasHeader>()
                .Property(e => e.whsCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_MermasHeader>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_MermasHeader>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_MermasHeader>()
                .Property(e => e.remarkId)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionEntry>()
                .Property(e => e.itemcode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionEntry>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionHeader>()
                .Property(e => e.whsCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionHeader>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionHeader>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionHeader>()
                .Property(e => e.codigoProducto)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_ProduccionHeader>()
                .Property(e => e.remarkId)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_RemarksTemp>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionEntry>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionEntry>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
                .Property(e => e.whsCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
                .Property(e => e.cardCode)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_SolicitudDevolucionHeader>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<centroCostoMap>()
                .Property(e => e.WhsCode)
                .IsUnicode(false);

            modelBuilder.Entity<centroCostoMap>()
                .Property(e => e.CentroCosto)
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

            modelBuilder.Entity<cbr_MapAlmacenesProduccion>()
                .Property(e => e.almacenTienda)
                .IsUnicode(false);

            modelBuilder.Entity<cbr_MapAlmacenesProduccion>()
                .Property(e => e.almacenProduccion)
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

            modelBuilder.Entity<SolicitudDevolucionSalesPersonCodes>()
                .Property(e => e.tienda)
                .IsUnicode(false);
        }
    }
}
