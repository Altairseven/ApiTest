using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestApi.Models
{
    public partial class ArcDbContext : DbContext
    {
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<TiposDocumentos> TiposDocumentos { get; set; }

        public ArcDbContext(DbContextOptions<ArcDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
