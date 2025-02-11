using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAllMaterialsAsync();
        Task<Material?> GetMaterialByIdAsync(int id);
        Task<Material?> CreateMaterialAsync(Material material);
        Task<bool> UpdateMaterialAsync(Material material);
        Task<bool> DeleteMaterialAsync(int id);
    }
}
