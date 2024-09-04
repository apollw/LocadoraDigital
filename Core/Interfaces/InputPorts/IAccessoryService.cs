using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IAccessoryService
    {
        Task AddAccessoryAsync(AccessoryTable accessory);
        Task<AccessoryTable> GetAccessoryByIdAsync(int id);
        Task<IEnumerable<AccessoryTable>> GetAllAccessoriesAsync();
        Task DeleteAccessoryAsync(int id);
        Task UpdateAccessoryAsync(AccessoryTable accessory);
    }
}
