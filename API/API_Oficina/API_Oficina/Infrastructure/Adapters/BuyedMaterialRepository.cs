using API_Oficina.Application;
using API_Oficina.Domain;
using API_Oficina.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Adapters
{
    public class BuyedMaterialRepository : IBuyedMaterialRepository
    {
        private readonly OficinaContext _context;
    
        public BuyedMaterialRepository(OficinaContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<BuyedMaterial>> GetAllAsync()
        {
            return await _context.BuyedMaterials.ToListAsync();
        }
    
        public async Task<BuyedMaterial?> GetByIdAsync(int id)
        {
            return await _context.BuyedMaterials.FindAsync(id);
        }
    
        public async Task<BuyedMaterial?> AddAsync(BuyedMaterial buyedMaterial)
        {
            _context.BuyedMaterials.Add(buyedMaterial);
            await _context.SaveChangesAsync();
            return buyedMaterial;
        }
    
        public async Task<bool> UpdateAsync(BuyedMaterial buyedMaterial)
        {
            _context.Entry(buyedMaterial).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    
        public async Task<bool> DeleteAsync(int id)
        {
            var buyedMaterial = await _context.BuyedMaterials.FindAsync(id);
            if (buyedMaterial == null) return false;
    
            _context.BuyedMaterials.Remove(buyedMaterial);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}