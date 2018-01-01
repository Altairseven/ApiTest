using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestApi.Models
{
    public partial class ArcDbContext : DbContext
    {
        public virtual DbSet<Heroes> Heroes { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<TiposDocumentos> TiposDocumentos { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public ArcDbContext(DbContextOptions<ArcDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Heroes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Quirk)
                    .HasColumnName("quirk")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodPostal)
                    .HasColumnName("COD_POSTAL")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdProvincia)
                    .HasColumnName("ID_PROVINCIA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("PERMISSIONS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("SYS_MENU");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ColorHeader)
                    .HasColumnName("Color_Header")
                    .HasMaxLength(8);

                entity.Property(e => e.Icono).HasMaxLength(50);

                entity.Property(e => e.IdPadre)
                    .HasColumnName("ID_Padre")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdSistema)
                    .HasColumnName("ID_Sistema")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Orden).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ruta)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TiposDocumentos>(entity =>
            {
                entity.ToTable("TIPOS_DOCUMENTOS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoAfip)
                    .HasColumnName("CODIGO_AFIP")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.IdPermissions)
                    .HasColumnName("ID_PERMISSIONS")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50);

                entity.Property(e => e.RecoveryA)
                    .HasColumnName("RECOVERY_A")
                    .HasMaxLength(50);

                entity.Property(e => e.RecoveryQ)
                    .HasColumnName("RECOVERY_Q")
                    .HasMaxLength(50);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("SALT")
                    .HasMaxLength(100);

                entity.Property(e => e.Userfirstname)
                    .IsRequired()
                    .HasColumnName("USERFIRSTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Userlastname)
                    .IsRequired()
                    .HasColumnName("USERLASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50);
            });
        }
    }
}
