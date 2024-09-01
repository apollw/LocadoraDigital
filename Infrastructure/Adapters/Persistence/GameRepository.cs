using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.OutputPorts;

namespace LocadoraDigital.Infrastructure.Adapters.Persistence
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> _games = new List<Game>();

        public Game GetById(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _games;
        }

        public void Add(Game game)
        {
            _games.Add(game);
        }

        public void Update(Game game)
        {
            var existingGame = GetById(game.Id);
            if (existingGame != null)
            {
                // Assuming you want to replace the whole game
                _games.Remove(existingGame);
                _games.Add(game);
            }
        }

        public void Delete(int id)
        {
            var game = GetById(id);
            if (game != null)
            {
                _games.Remove(game);
            }
        }
    }
}

