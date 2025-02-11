using API_Oficina.Domain;

namespace API_Oficina.Application{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;
    
        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<IEnumerable<Work>> GetAllWorksAsync()
        {
            return await _workRepository.GetAllAsync();
        }
    
        public async Task<Work?> GetWorkByIdAsync(int id)
        {
            return await _workRepository.GetByIdAsync(id);
        }
    
        public async Task<Work?> CreateWorkAsync(Work work)
        {
            return await _workRepository.AddAsync(work);
        }
    
        public async Task<bool> UpdateWorkAsync(Work work)
        {
            return await _workRepository.UpdateAsync(work);
        }
    
        public async Task<bool> DeleteWorkAsync(int id)
        {
            return await _workRepository.DeleteAsync(id);
        }
    
        public async Task<float> EstimatePriceByByWorkTypeAsync(int? workTypeId)
        {
            var works = await _workRepository.GetWorksByTypeAsync(workTypeId);
            if (works == null || !works.Any())
                return 0;
    
            return works.Average(w => w.CurrentPrice);
        }

        public async Task<float> EstimateRevenueForThisMonth()
        {

        }
    }
}
