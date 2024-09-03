using LocadoraDigital.Core.Entities;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IClientService
    {
        Task AddClientAsync(ClientTable client);
    }
}
