using Microsoft.EntityFrameworkCore;
using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Infrastructure.Data
{
    public class MovilidadDbContext : DbContext
    {
        public MovilidadDbContext(DbContextOptions<MovilidadDbContext> options) : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<RutaPredeterminada> RutasPredeterminadas { get; set; }
        public DbSet<Coordenada> Coordenadas { get; set; }
        public DbSet<HistorialViaje> HistorialViajes { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Vehiculo
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Latitud).IsRequired();
                entity.Property(e => e.Longitud).IsRequired();
                entity.Property(e => e.Combustible).IsRequired();
                entity.Property(e => e.Tipo).HasMaxLength(50);
                entity.Property(e => e.Estado).HasMaxLength(100);
                entity.Property(e => e.UltimaActualizacion).IsRequired().HasDefaultValue(DateTime.UtcNow);
            });

            // Configuración de Ubicacion
            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Latitud).IsRequired();
                entity.Property(e => e.Longitud).IsRequired();
            });

            // Configuración de RutaPredeterminada
            modelBuilder.Entity<RutaPredeterminada>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.OrigenlocationId).IsRequired();
                entity.Property(e => e.DestinoLocationId).IsRequired();
                entity.Property(e => e.NivelTraficoActual).HasDefaultValue(0);

                // FK a Ubicacion para Origen
                entity.HasOne(r => r.OrigenlLocation)
                    .WithMany()
                    .HasForeignKey(r => r.OrigenlocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                // FK a Ubicacion para Destino
                entity.HasOne(r => r.DestinoLocation)
                    .WithMany()
                    .HasForeignKey(r => r.DestinoLocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación 1:N con Coordenada
                entity.HasMany(r => r.Coordenadas)
                    .WithOne(c => c.RutaPredeterminada)
                    .HasForeignKey(c => c.RutaPredeterminadaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Coordenada
            modelBuilder.Entity<Coordenada>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RutaPredeterminadaId).IsRequired();
                entity.Property(e => e.Latitud).IsRequired();
                entity.Property(e => e.Longitud).IsRequired();
                entity.Property(e => e.Orden).HasDefaultValue(0);
            });

            modelBuilder.Entity<HistorialViaje>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VehiculoId).IsRequired();
                entity.Property(e => e.OrigenLocationId).IsRequired();
                entity.Property(e => e.DestinoLocationId).IsRequired();
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(50);
                entity.Property(e => e.InicioUtc).IsRequired().HasDefaultValue(DateTime.UtcNow);
                entity.Property(e => e.DistanciaKm).HasColumnType("decimal(10,2)");
                entity.Property(e => e.CostoEstimado).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Vehiculo)
                    .WithMany()
                    .HasForeignKey(e => e.VehiculoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.OrigenLocation)
                    .WithMany()
                    .HasForeignKey(e => e.OrigenLocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.DestinoLocation)
                    .WithMany()
                    .HasForeignKey(e => e.DestinoLocationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.HistorialViajeId).IsRequired();
                entity.Property(e => e.Monto).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Moneda).IsRequired().HasMaxLength(3).HasDefaultValue("MXN");
                entity.Property(e => e.Metodo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Referencia).HasMaxLength(100);
                entity.Property(e => e.FechaUtc).IsRequired().HasDefaultValueSql("sysutcdatetime()");

                entity.HasOne(e => e.HistorialViaje)
                    .WithMany()
                    .HasForeignKey(e => e.HistorialViajeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Pagos_HistorialViajes");

                entity.ToTable("Pagos");
            });
        }


    }
}
