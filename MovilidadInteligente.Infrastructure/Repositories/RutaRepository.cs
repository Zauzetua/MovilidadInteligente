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
    public class RutaRepository : IRutaRepository
    {
        private readonly MovilidadDbContext _context;

        public RutaRepository(MovilidadDbContext context)
        {
            _context = context;
        }

        public async Task<RutaPredeterminada> AddAsync(RutaPredeterminada ruta)
        {
            var existe = await _context.RutasPredeterminadas.AnyAsync(r => r.Id == ruta.Id);
            if (existe)
                throw new InvalidOperationException($"La ruta con ID '{ruta.Id}' ya existe.");

            await _context.RutasPredeterminadas.AddAsync(ruta);
            await _context.SaveChangesAsync();
            return ruta;
        }

        public async Task<RutaPredeterminada> GetByIdAsync(string id)
        {
            var ruta = await _context.RutasPredeterminadas
                .Include(r => r.Coordenadas)
                .Include(r => r.OrigenlLocation)
                .Include(r => r.DestinoLocation)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (ruta == null)
                throw new KeyNotFoundException($"Ruta con ID '{id}' no encontrada.");

            return ruta;
        }

        public async Task<IEnumerable<RutaPredeterminada>> GetAllAsync()
        {
            return await _context.RutasPredeterminadas
                .Include(r => r.Coordenadas)
                .Include(r => r.OrigenlLocation)
                .Include(r => r.DestinoLocation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RutaPredeterminada> UpdateAsync(RutaPredeterminada ruta)
        {
            var existe = await _context.RutasPredeterminadas.AnyAsync(r => r.Id == ruta.Id);
            if (!existe)
                throw new KeyNotFoundException($"Ruta con ID '{ruta.Id}' no encontrada.");

            _context.RutasPredeterminadas.Update(ruta);
            await _context.SaveChangesAsync();
            return ruta;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var ruta = await _context.RutasPredeterminadas.FindAsync(id);
            if (ruta == null)
                return false;

            _context.RutasPredeterminadas.Remove(ruta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RutaPredeterminada>> GetByOriginDestinationAsync(string origenLocationId, string destinoLocationId)
        {
            return await _context.RutasPredeterminadas
                .Include(r => r.Coordenadas)
                .Include(r => r.OrigenlLocation)
                .Include(r => r.DestinoLocation)
                .Where(r => r.OrigenlocationId == origenLocationId && r.DestinoLocationId == destinoLocationId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
