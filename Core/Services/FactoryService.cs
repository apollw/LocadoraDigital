using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Services
{
    public class FactoryService
    {
        private readonly IFactoryService<GameTable> _gameFactory;

        public FactoryService(IFactoryService<GameTable> gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public GameTable CreateGame()
        {
            return _gameFactory.Create();
        }
    }
}
