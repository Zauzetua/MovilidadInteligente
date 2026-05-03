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
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly MovilidadDbContext _context;

        public UbicacionRepository(MovilidadDbContext context)
        {
            _context = context;
        }

        public async Task<Ubicacion> AddAsync(Ubicacion ubicacion)
        {
            var existe = await _context.Ubicaciones.AnyAsync(u => u.Id == ubicacion.Id);
            if (existe)
                throw new InvalidOperationException($"La ubicación con ID '{ubicacion.Id}' ya existe.");

            await _context.Ubicaciones.AddAsync(ubicacion);
            await _context.SaveChangesAsync();
            return ubicacion;
        }

        public async Task<Ubicacion> GetByIdAsync(string id)
        {
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
                throw new KeyNotFoundException($"Ubicación con ID '{id}' no encontrada.");
            return ubicacion;
        }

        public async Task<IEnumerable<Ubicacion>> GetAllAsync()
        {
            return await _context.Ubicaciones.AsNoTracking().ToListAsync();
        }

        public async Task<Ubicacion> UpdateAsync(Ubicacion ubicacion)
        {
            var existe = await _context.Ubicaciones.AnyAsync(u => u.Id == ubicacion.Id);
            if (!existe)
                throw new KeyNotFoundException($"Ubicación con ID '{ubicacion.Id}' no encontrada.");

            _context.Ubicaciones.Update(ubicacion);
            await _context.SaveChangesAsync();
            return ubicacion;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
                return false;

            _context.Ubicaciones.Remove(ubicacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
