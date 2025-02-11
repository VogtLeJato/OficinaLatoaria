using API_Oficina.Application;
using API_Oficina.Domain;
using API_Oficina.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Adapters
{
    public class ClientRepository : IClientRepository
    {
        private readonly OficinaContext _context;

        public ClientRepository(OficinaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client?> AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> UpdateAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return false;
            }

            _context.Clients.Remove(client);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
