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
    public class PagoRepository : IPagoRepository
    {
        private readonly MovilidadDbContext _context;

        public PagoRepository(MovilidadDbContext context)
        {
            _context = context;
        }

        public async Task<Pago> AddAsync(Pago pago)
        {
            var existe = await _context.Pagos.AnyAsync(p => p.Id == pago.Id);
            if (existe)
                throw new InvalidOperationException($"El pago con ID '{pago.Id}' ya existe.");

            await _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<Pago> GetByIdAsync(string id)
        {
            var pago = await _context.Pagos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (pago == null)
                throw new KeyNotFoundException($"Pago con ID '{id}' no encontrado.");
            return pago;
        }

        public async Task<IEnumerable<Pago>> GetAllAsync()
        {
            return await _context.Pagos.AsNoTracking().OrderByDescending(p => p.FechaUtc).ToListAsync();
        }

        public async Task<IEnumerable<Pago>> GetByHistorialViajeIdAsync(string historialViajeId)
        {
            return await _context.Pagos
                .AsNoTracking()
                .Where(p => p.HistorialViajeId == historialViajeId)
                .OrderByDescending(p => p.FechaUtc)
                .ToListAsync();
        }

        public async Task<Pago> UpdateAsync(Pago pago)
        {
            var existe = await _context.Pagos.AnyAsync(p => p.Id == pago.Id);
            if (!existe)
                throw new KeyNotFoundException($"Pago con ID '{pago.Id}' no encontrado.");

            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
                return false;

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
