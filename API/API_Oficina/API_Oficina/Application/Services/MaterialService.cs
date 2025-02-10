using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await _materialRepository.GetAllAsync();
        }

        public async Task<Material?> GetMaterialByIdAsync(int id)
        {
            return await _materialRepository.GetByIdAsync(id);
        }

        public async Task<Material?> CreateMaterialAsync(Material material)
        {
            return await _materialRepository.AddAsync(material);
        }

        public async Task<bool> UpdateMaterialAsync(Material material)
        {
            return await _materialRepository.UpdateAsync(material);
        }

        public async Task<bool> DeleteMaterialAsync(int id)
        {
            return await _materialRepository.DeleteAsync(id);
        }
    }
}
