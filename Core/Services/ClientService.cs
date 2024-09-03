using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Core.Services;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public ClientService(DatabaseConfig databaseConfig)
        {
            _dbConnection = databaseConfig.GetDbConnection();
        }

        public async Task AddClientAsync(ClientTable client)
        {
            await _dbConnection.InsertAsync(client);
        }
    }
}

