using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TiendaTecnologica.Models
{
    public partial class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TIENDA_COMPRAS;Integrated Security=True");
                 optionsBuilder.UseSqlServer("Data Source=DESKTOP-5BOITM6\\MARIA;Initial Catalog=TIENDA_COMPRAS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("CATEGORIAS");

                entity.Property(e => e.CatId)
                    .HasColumnName("CAT_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CatDescricion)
                    .IsRequired()
                    .HasColumnName("CAT_DESCRICION")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.DetId);

                entity.ToTable("DETALLE_VENTA");

                entity.Property(e => e.DetId)
                    .HasColumnName("DET_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DetCantidad).HasColumnName("DET_CANTIDAD");

                entity.Property(e => e.DetPrecio)
                    .HasColumnName("DET_PRECIO")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.DetSubtotal)
                    .HasColumnName("DET_SUBTOTAL")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.ProId)
                    .IsRequired()
                    .HasColumnName("PRO_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VenId)
                    .IsRequired()
                    .HasColumnName("VEN_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DET_PRO");

                entity.HasOne(d => d.Ven)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DET_VEN");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CatId)
                    .IsRequired()
                    .HasColumnName("CAT_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProCantidad).HasColumnName("PRO_CANTIDAD");

                entity.Property(e => e.ProDescricion)
                    .IsRequired()
                    .HasColumnName("PRO_DESCRICION")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProImagen)
                    .IsRequired()
                    .HasColumnName("PRO_IMAGEN")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProPrecio)
                    .HasColumnName("PRO_PRECIO")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRO_CAT");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.UsuId).HasColumnName("USU_ID");

                entity.Property(e => e.UsuContraseña)
                    .IsRequired()
                    .HasColumnName("USU_CONTRASEÑA")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuCorreo)
                    .IsRequired()
                    .HasColumnName("USU_CORREO")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("USU_NOMBRE")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuUsuario)
                    .IsRequired()
                    .HasColumnName("USU_USUARIO")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.VenId);

                entity.ToTable("VENTA");

                entity.Property(e => e.VenId)
                    .HasColumnName("VEN_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VenCliente)
                    .IsRequired()
                    .HasColumnName("VEN_CLIENTE")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VenFecha)
                    .IsRequired()
                    .HasColumnName("VEN_FECHA")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VenImpuesto)
                    .HasColumnName("VEN_IMPUESTO")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.VenSubtotal)
                    .HasColumnName("VEN_SUBTOTAL")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.VenTotal)
                    .HasColumnName("VEN_TOTAL")
                    .HasColumnType("decimal(13, 2)");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.ConId);

                entity.ToTable("CONTACTO");

                entity.Property(e => e.ConId)
                    .HasColumnName("CON_ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("CON_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("CON_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("CON_Mensaje")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
