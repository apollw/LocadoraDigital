using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Interfaces.OutputPorts
{
    public class AccessoryService : IAccessoryService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public AccessoryService(DatabaseConfig databaseConfig)
        {
            _dbConnection = databaseConfig.GetDbConnection();
        }

        public async Task AddAccessoryAsync(AccessoryTable accessory)
        {
            await _dbConnection.InsertAsync(accessory);
        }

        public async Task<AccessoryTable> GetAccessoryByIdAsync(int id)
        {
            return await _dbConnection.FindAsync<AccessoryTable>(id);
        }

        public async Task<IEnumerable<AccessoryTable>> GetAllAccessoriesAsync()
        {
            return await _dbConnection.Table<AccessoryTable>().ToListAsync();
        }

        public async Task DeleteAccessoryAsync(int id)
        {
            var accessory = await _dbConnection.FindAsync<AccessoryTable>(id);
            if (accessory != null)
            {
                await _dbConnection.DeleteAsync(accessory);
            }
        }

        public async Task UpdateAccessoryAsync(AccessoryTable accessory)
        {
            await _dbConnection.UpdateAsync(accessory);
        }
    }
}
