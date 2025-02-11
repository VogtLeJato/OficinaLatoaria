using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IWorkTypeService
    {
        Task<IEnumerable<WorkType>> GetAllWorkTypesAsync();
        Task<WorkType?> GetWorkTypeByIdAsync(int id);
        Task<WorkType?> CreateWorkTypeAsync(WorkType workType);
        Task<bool> UpdateWorkTypeAsync(WorkType workType);
        Task<bool> DeleteWorkTypeAsync(int id);
    }
}
