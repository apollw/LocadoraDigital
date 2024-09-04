using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Interfaces.OutputPorts
{
    public class PlatformService : IPlatformService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public PlatformService(DatabaseConfig databaseConfig)
        {
            _dbConnection = databaseConfig.GetDbConnection();
        }

        public async Task AddPlatformAsync(PlatformTable platform)
        {
            await _dbConnection.InsertAsync(platform);
        }

        public async Task<PlatformTable> GetPlatformByIdAsync(int id)
        {
            return await _dbConnection.FindAsync<PlatformTable>(id);
        }

        public async Task<IEnumerable<PlatformTable>> GetAllPlatformsAsync()
        {
            return await _dbConnection.Table<PlatformTable>().ToListAsync();
        }

        public async Task DeletePlatformAsync(int id)
        {
            var game = await _dbConnection.FindAsync<PlatformTable>(id);
            if (game != null)
            {
                await _dbConnection.DeleteAsync(game);
            }
        }

        public async Task UpdatePlatformAsync(PlatformTable platform)
        {
            await _dbConnection.UpdateAsync(platform);
        }        
    }
}
