using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<Client?> AddAsync(Client client);
        Task<bool> UpdateAsync(Client client);
        Task<bool> DeleteAsync(int id);
    }
}
