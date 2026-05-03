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
        }


    }
}
