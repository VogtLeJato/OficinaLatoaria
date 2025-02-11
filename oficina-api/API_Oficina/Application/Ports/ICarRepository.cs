using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(int id);
        Task<Car?> AddAsync(Car work);
        Task<bool> UpdateAsync(Car work);
        Task<bool> DeleteAsync(int id);
    }
}