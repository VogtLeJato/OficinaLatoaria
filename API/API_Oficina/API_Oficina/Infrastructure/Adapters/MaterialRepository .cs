using API_Oficina.Application;
using API_Oficina.Domain;
using API_Oficina.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Adapters
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly OficinaContext _context;
        public MaterialRepository(OficinaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            return await _context.Materials.ToListAsync();
        }
        public async Task<Material?> GetByIdAsync(int id)
        {
            return await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Material?> AddAsync(Material material)
        {
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
            return material;
        }
        public async Task<bool> UpdateAsync(Material material)
        {
            _context.Entry(material).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return false;
            }
            _context.Materials.Remove(material);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}