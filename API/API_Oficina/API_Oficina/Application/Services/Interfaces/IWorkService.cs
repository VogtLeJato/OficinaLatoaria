using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IWorkService
    {
        Task<IEnumerable<Work>> GetAllWorksAsync();
        Task<Work?> GetWorkByIdAsync(int id);
        Task<Work?> CreateWorkAsync(Work work);
        Task<bool> UpdateWorkAsync(Work work);
        Task<bool> DeleteWorkAsync(int id);
        Task<float> CalcularMediaPrecoTrabalhoAsync(int? workTypeId);
    }
}