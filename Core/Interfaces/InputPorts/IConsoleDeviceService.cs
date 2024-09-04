using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IConsoleDeviceService
    {
        Task AddConsoleDeviceAsync(ConsoleDeviceTable consoleDevice);
        Task<ConsoleDeviceTable> GetConsoleDeviceByIdAsync(int id);
        Task<IEnumerable<ConsoleDeviceTable>> GetAllConsoleDevicesAsync();
        Task DeleteConsoleDeviceAsync(int id);
        Task UpdateConsoleDeviceAsync(ConsoleDeviceTable consoleDevice);

        // Métodos de Games
        Task AddGamePlatformAsync(GamePlatformTable gamePlatform);
    }
}
