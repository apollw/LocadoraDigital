using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Interfaces.OutputPorts
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

        public async Task<ClientTable> GetClientByIdAsync(int id)
        {
            return await _dbConnection.FindAsync<ClientTable>(id);
        }

        public async Task<IEnumerable<ClientTable>> GetAllClientsAsync()
        {
            return await _dbConnection.Table<ClientTable>().ToListAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _dbConnection.FindAsync<ClientTable>(id);
            if (client != null)
            {
                await _dbConnection.DeleteAsync(client);
            }
        }

        public async Task UpdateClientAsync(ClientTable client)
        {
            await _dbConnection.UpdateAsync(client);
        }

    }
}

