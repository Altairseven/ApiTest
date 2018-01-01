using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestApi.ProyectoresModel
{
    public partial class ProyectoresDbContext : DbContext
    {
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<MotivoBajaReserva> MotivoBajaReserva { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Proyectores> Proyectores { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Salones> Salones { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TiposPersona> TiposPersona { get; set; }

        public ProyectoresDbContext(DbContextOptions<ProyectoresDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
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

            modelBuilder.Entity<MotivoBajaReserva>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(50);

                entity.Property(e => e.Cuit)
                    .HasColumnName("CUIT")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(50);

                entity.Property(e => e.Documento)
                    .HasColumnName("DOCUMENTO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(70);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdLocalidad)
                    .HasColumnName("ID_LOCALIDAD")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdTipoDocumento)
                    .HasColumnName("ID_TIPO_DOCUMENTO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdTipoPersona)
                    .HasColumnName("ID_TIPO_PERSONA")
                    .HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Legajo)
                    .HasColumnName("LEGAJO")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prestamos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.HDesde)
                    .HasColumnName("H_DESDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.HHasta)
                    .HasColumnName("H_HASTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("ID_PERSONA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdProyector)
                    .HasColumnName("ID_PROYECTOR")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdReserva)
                    .HasColumnName("ID_RESERVA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdSalon)
                    .HasColumnName("ID_SALON")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Proyectores>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Disponible)
                    .HasColumnName("DISPONIBLE")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Hdmi)
                    .HasColumnName("HDMI")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Marca)
                    .HasColumnName("MARCA")
                    .HasMaxLength(50);

                entity.Property(e => e.Modelo)
                    .HasColumnName("MODELO")
                    .HasMaxLength(50);

                entity.Property(e => e.Operativo)
                    .HasColumnName("OPERATIVO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasColumnName("SERIAL");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("FECHA_ALTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("FECHA_BAJA")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaReserva)
                    .HasColumnName("FECHA_RESERVA")
                    .HasColumnType("datetime");

                entity.Property(e => e.HDesde)
                    .HasColumnName("H_DESDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.HHasta)
                    .HasColumnName("H_HASTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMotivoBaja)
                    .HasColumnName("ID_MOTIVO_BAJA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("ID_PERSONA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdSalon)
                    .HasColumnName("ID_SALON")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Salones>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("Tipo_Documento");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TiposPersona>(entity =>
            {
                entity.ToTable("Tipos_Persona");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);
            });
        }
    }
}
