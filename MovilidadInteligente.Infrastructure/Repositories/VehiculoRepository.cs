using Microsoft.EntityFrameworkCore;
using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Domain.Entities;
using MovilidadInteligente.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly MovilidadDbContext _context;

        public VehiculoRepository(MovilidadDbContext context)
        {
            _context = context;
        }
        public async Task ActualizarTelemetriaAsync(Vehiculo vehiculo)
        {
            var existe = await _context.Vehiculos.AnyAsync(v => v.Id == vehiculo.Id);

            if (existe)
            {
                _context.Vehiculos.Update(vehiculo);
            }
            else
            {
                await _context.Vehiculos.AddAsync(vehiculo);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Vehiculo> ObtenerPorIdAsync(string id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"No se encontro un vehículo con el ID '{id}'.");
            }

            return vehiculo;
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerTodosAsync()
        {
            return await _context.Vehiculos.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerVehiculosInactivosAsync(DateTime limiteInactividad)
        {
            return await _context.Vehiculos
                .Where(v => v.UltimaActualizacion < limiteInactividad && v.Estado != "Desconectado")
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
