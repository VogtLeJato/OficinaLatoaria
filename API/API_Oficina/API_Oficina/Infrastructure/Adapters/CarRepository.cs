using API_Oficina.Application;
using API_Oficina.Domain;
using API_Oficina.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Adapters
{
    public class CarRepository : ICarRepository
    {
        private readonly OficinaContext _context;
    
        public CarRepository(OficinaContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }
    
        public async Task<Car?> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }
    
        public async Task<Car?> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
    
        public async Task<bool> UpdateAsync(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    
        public async Task<bool> DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return false;
    
            _context.Cars.Remove(car);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}