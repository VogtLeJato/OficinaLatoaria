using Microsoft.AspNetCore.Mvc;
using API_Oficina.Domain;
using API_Oficina.Application;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return clients == null || !clients.Any() ? NotFound() : Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            return client == null ? NotFound() : Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.Id) return BadRequest();
            var updated = await _clientService.UpdateClientAsync(client);
            return updated ? NoContent() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            var createdClient = await _clientService.CreateClientAsync(client);
            return createdClient == null ? BadRequest() : CreatedAtAction(nameof(GetClient), new { id = createdClient.Id }, createdClient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var deleted = await _clientService.DeleteClientAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
