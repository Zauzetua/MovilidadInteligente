using Microsoft.EntityFrameworkCore;
using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Domain.Entities;
using MovilidadInteligente.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovilidadInteligente.Infrastructure.Repositories
{
    public class HistorialViajeRepository : IHistorialViajeRepository
    {
        private readonly MovilidadDbContext _context;

        public HistorialViajeRepository(MovilidadDbContext context)
        {
            _context = context;
        }

        public async Task<HistorialViaje> AddAsync(HistorialViaje historial)
        {
            var existe = await _context.HistorialViajes.AnyAsync(h => h.Id == historial.Id);
            if (existe)
                throw new InvalidOperationException($"El historial con ID '{historial.Id}' ya existe.");

            await _context.HistorialViajes.AddAsync(historial);
            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task<HistorialViaje> GetByIdAsync(string id)
        {
            var historial = await _context.HistorialViajes.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (historial == null)
                throw new KeyNotFoundException($"Historial con ID '{id}' no encontrado.");
            return historial;
        }

        public async Task<IEnumerable<HistorialViaje>> GetAllAsync()
        {
            return await _context.HistorialViajes.AsNoTracking().ToListAsync();
        }

        public async Task<HistorialViaje?> GetActivoPorVehiculoAsync(string vehiculoId)
        {
            return await _context.HistorialViajes
                .AsNoTracking()
                .Where(h => h.VehiculoId == vehiculoId && h.FinUtc == null)
                .OrderByDescending(h => h.InicioUtc)
                .FirstOrDefaultAsync();
        }

        public async Task<HistorialViaje> UpdateAsync(HistorialViaje historial)
        {
            var existe = await _context.HistorialViajes.AnyAsync(h => h.Id == historial.Id);
            if (!existe)
                throw new KeyNotFoundException($"Historial con ID '{historial.Id}' no encontrado.");

            _context.HistorialViajes.Update(historial);
            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var historial = await _context.HistorialViajes.FindAsync(id);
            if (historial == null)
                return false;

            _context.HistorialViajes.Remove(historial);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
