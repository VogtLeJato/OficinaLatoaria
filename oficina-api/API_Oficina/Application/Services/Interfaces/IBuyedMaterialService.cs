using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IBuyedMaterialService
    {
        Task<IEnumerable<BuyedMaterial>> GetAllBuyedMaterialsAsync();
        Task<BuyedMaterial?> GetBuyedMaterialByIdAsync(int id);
        Task<BuyedMaterial?> CreateBuyedMaterialAsync(BuyedMaterial buyedMaterial);
        Task<bool> UpdateBuyedMaterialAsync(BuyedMaterial buyedMaterial);
        Task<bool> DeleteBuyedMaterialAsync(int id);
    }
}
