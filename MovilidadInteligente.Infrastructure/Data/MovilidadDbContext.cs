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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Latitud).IsRequired();
                entity.Property(e => e.Longitud).IsRequired();
                entity.Property(e => e.Combustible).IsRequired();
                entity.Property(e => e.Tipo).HasMaxLength(50);
                entity.Property(e => e.Estado).HasMaxLength(100);
            });
        }


    }
}
