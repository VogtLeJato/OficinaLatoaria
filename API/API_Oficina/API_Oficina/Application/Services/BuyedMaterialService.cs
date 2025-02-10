using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public class BuyedMaterialService : IBuyedMaterialService
    {
        private readonly IBuyedMaterialRepository _buyedMaterialRepository;

        public BuyedMaterialService(IBuyedMaterialRepository buyedMaterialRepository)
        {
            _buyedMaterialRepository = buyedMaterialRepository;
        }

        public async Task<IEnumerable<BuyedMaterial>> GetAllBuyedMaterialsAsync()
        {
            return await _buyedMaterialRepository.GetAllAsync();
        }

        public async Task<BuyedMaterial?> GetBuyedMaterialByIdAsync(int id)
        {
            return await _buyedMaterialRepository.GetByIdAsync(id);
        }

        public async Task<BuyedMaterial?> CreateBuyedMaterialAsync(BuyedMaterial buyedMaterial)
        {
            return await _buyedMaterialRepository.AddAsync(buyedMaterial);
        }

        public async Task<bool> UpdateBuyedMaterialAsync(BuyedMaterial buyedMaterial)
        {
            return await _buyedMaterialRepository.UpdateAsync(buyedMaterial);
        }

        public async Task<bool> DeleteBuyedMaterialAsync(int id)
        {
            return await _buyedMaterialRepository.DeleteAsync(id);
        }
    }
}