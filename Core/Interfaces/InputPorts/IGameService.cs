using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IGameService
    {
        Task AddGameAsync(GameTable game);
        Task<GameTable> GetGameByIdAsync(int id);
        Task<IEnumerable<GameTable>> GetAllGamesAsync();
        Task DeleteGamesAsync(int id);
        Task UpdateGameAsync(GameTable game);
    }
}
