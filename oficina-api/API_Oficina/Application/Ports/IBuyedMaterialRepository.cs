using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IBuyedMaterialRepository
    {
        Task<IEnumerable<BuyedMaterial>> GetAllAsync();
        Task<BuyedMaterial?> GetByIdAsync(int id);
        Task<BuyedMaterial?> AddAsync(BuyedMaterial work);
        Task<bool> UpdateAsync(BuyedMaterial work);
        Task<bool> DeleteAsync(int id);
    }
}