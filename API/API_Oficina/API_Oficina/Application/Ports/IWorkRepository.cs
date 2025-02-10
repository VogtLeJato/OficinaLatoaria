using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IWorkRepository
    {
        Task<IEnumerable<Work>> GetAllAsync();
        Task<Work?> GetByIdAsync(int id);
        Task<Work?> AddAsync(Work work);
        Task<bool> UpdateAsync(Work work);
        Task<bool> DeleteAsync(int id);
        Task<List<Work>> GetWorksByTypeAsync(int? workTypeId = null);
    }
}