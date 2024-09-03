using LocadoraDigital.Core.Entities;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IClientService
    {
        Task AddClientAsync(ClientTable client);
        Task<ClientTable> GetClientByIdAsync(int id);
        Task<IEnumerable<ClientTable>> GetAllClientsAsync();
        Task DeleteClientAsync(int id);
        Task UpdateClientAsync(ClientTable client);  
    }
}
