using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Services
{
    public class GameService : IGameService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public GameService(DatabaseConfig databaseConfig)
        {
            _dbConnection = databaseConfig.GetDbConnection();
        }

        public async Task AddGameAsync(GameTable game)
        {
            await _dbConnection.InsertAsync(game);
        }

        public async Task<GameTable> GetGameByIdAsync(int id)
        {
            return await _dbConnection.FindAsync<GameTable>(id);
        }

        public async Task<IEnumerable<GameTable>> GetAllGamesAsync()
        {
            return await _dbConnection.Table<GameTable>().ToListAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _dbConnection.FindAsync<GameTable>(id);
            if (game != null)
            {
                await _dbConnection.DeleteAsync(game);
            }
        }

        public async Task UpdateGameAsync(GameTable game)
        {
            await _dbConnection.UpdateAsync(game);
        }

    }
}

