using API_Oficina.Application;
using API_Oficina.Domain;
using API_Oficina.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Adapters
{
    public class WorkRepository : IWorkRepository
    {
        private readonly OficinaContext _context;
        public WorkRepository(OficinaContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<Work>> GetAllAsync()
        {
            return await _context.Works.ToListAsync();
        }
    
        public async Task<Work?> GetByIdAsync(int id)
        {
            return await _context.Works.FindAsync(id);
        }
    
        public async Task<Work?> AddAsync(Work work)
        {
            _context.Works.Add(work);
            await _context.SaveChangesAsync();
            return work;
        }
    
        public async Task<bool> UpdateAsync(Work work)
        {
            _context.Entry(work).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    
        public async Task<bool> DeleteAsync(int id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work == null) return false;
    
            _context.Works.Remove(work);
            return await _context.SaveChangesAsync() > 0;
        }
    
        public async Task<List<Work>> GetWorksByTypeAsync(int? workTypeId = null)
        {
            return await _context.Works
                                 .Where(w => workTypeId == null ? w.Type == null : w.Type != null && w.Type.Id == workTypeId)
                                 .ToListAsync();
        }
    }
}