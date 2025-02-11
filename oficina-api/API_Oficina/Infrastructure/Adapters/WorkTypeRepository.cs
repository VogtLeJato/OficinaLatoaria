using API_Oficina.Application;
using API_Oficina.Domain;
using API_Oficina.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Adapters
{
    public class WorkTypeRepository : IWorkTypeRepository
    {
        private readonly OficinaContext _context;
    
        public WorkTypeRepository(OficinaContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<WorkType>> GetAllAsync()
        {
            return await _context.WorkTypes.ToListAsync();
        }
    
        public async Task<WorkType?> GetByIdAsync(int id)
        {
            return await _context.WorkTypes.FindAsync(id);
        }
    
        public async Task<WorkType?> AddAsync(WorkType workType)
        {
            _context.WorkTypes.Add(workType);
            await _context.SaveChangesAsync();
            return workType;
        }
    
        public async Task<bool> UpdateAsync(WorkType workType)
        {
            _context.Entry(workType).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    
        public async Task<bool> DeleteAsync(int id)
        {
            var workType = await _context.WorkTypes.FindAsync(id);
            if (workType == null) return false;
    
            _context.WorkTypes.Remove(workType);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}