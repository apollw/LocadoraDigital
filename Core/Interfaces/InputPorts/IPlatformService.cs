using LocadoraDigital.Core.Entities;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IPlatformService
    {
        Task AddPlatformAsync(PlatformTable platform);
        Task<PlatformTable> GetPlatformByIdAsync(int id);
        Task<IEnumerable<PlatformTable>> GetAllPlatformsAsync();
        Task DeletePlatformAsync(int id);
        Task UpdatePlatformAsync(PlatformTable platform);        
    }
}
