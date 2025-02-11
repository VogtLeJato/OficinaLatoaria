using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllAsync();
        Task<Material?> GetByIdAsync(int id);
        Task<Material?> AddAsync(Material material);
        Task<bool> UpdateAsync(Material material);
        Task<bool> DeleteAsync(int id);
    }
}
