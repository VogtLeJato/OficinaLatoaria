using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IWorkTypeRepository _workTypeRepository;

        public WorkTypeService(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }

        public async Task<IEnumerable<WorkType>> GetAllWorkTypesAsync()
        {
            return await _workTypeRepository.GetAllAsync();
        }

        public async Task<WorkType?> GetWorkTypeByIdAsync(int id)
        {
            return await _workTypeRepository.GetByIdAsync(id);
        }

        public async Task<WorkType?> CreateWorkTypeAsync(WorkType workType)
        {
            return await _workTypeRepository.AddAsync(workType);
        }

        public async Task<bool> UpdateWorkTypeAsync(WorkType workType)
        {
            return await _workTypeRepository.UpdateAsync(workType);
        }

        public async Task<bool> DeleteWorkTypeAsync(int id)
        {
            return await _workTypeRepository.DeleteAsync(id);
        }
    }
}
