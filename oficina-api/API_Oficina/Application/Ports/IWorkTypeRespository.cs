using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IWorkTypeRepository
    {
        Task<IEnumerable<WorkType>> GetAllAsync();
        Task<WorkType?> GetByIdAsync(int id);
        Task<WorkType?> AddAsync(WorkType work);
        Task<bool> UpdateAsync(WorkType work);
        Task<bool> DeleteAsync(int id);
    }
}