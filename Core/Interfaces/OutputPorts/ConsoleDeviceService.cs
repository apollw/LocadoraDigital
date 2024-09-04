using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Interfaces.OutputPorts
{
    public class ConsoleDeviceService : IConsoleDeviceService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public ConsoleDeviceService(DatabaseConfig databaseConfig)
        {
            _dbConnection = databaseConfig.GetDbConnection();
        }

        public async Task AddConsoleDeviceAsync(ConsoleDeviceTable consoleDevice)
        {
            await _dbConnection.InsertAsync(consoleDevice);
        }

        public async Task<ConsoleDeviceTable> GetConsoleDeviceByIdAsync(int id)
        {
            return await _dbConnection.FindAsync<ConsoleDeviceTable>(id);
        }

        public async Task<IEnumerable<ConsoleDeviceTable>> GetAllConsoleDevicesAsync()
        {
            return await _dbConnection.Table<ConsoleDeviceTable>().ToListAsync();
        }

        public async Task DeleteConsoleDeviceAsync(int id)
        {
            var consoleDevice = await _dbConnection.FindAsync<ConsoleDeviceTable>(id);
            if (consoleDevice != null)
            {
                await _dbConnection.DeleteAsync(consoleDevice);
            }
        }

        public async Task UpdateConsoleDeviceAsync(ConsoleDeviceTable consoleDevice)
        {
            await _dbConnection.UpdateAsync(consoleDevice);
        }

        public async Task AddGamePlatformAsync(GamePlatformTable gamePlatform)
        {
            await _dbConnection.InsertAsync(gamePlatform);
        }
    }
}
