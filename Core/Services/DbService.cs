using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Configurations;

namespace LocadoraDigital.Core.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseConfig _databaseConfig;

        public DbService(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task InitializeAsync()
        {
            await _databaseConfig.InitializeAsync();
        }
    }
}


