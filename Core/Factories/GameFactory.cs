using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Factories
{
    public class GameFactory : IFactoryService<GameTable>
    {
        public GameTable Create(int id, string title, List<GamePlatform> platforms)
        {
            return new GameTable
            {
                Id = id,
                Title = title,
                Platforms = platforms
            };
        }

        public GameTable Create()
        {
            return new GameTable
            {
                
            };
        }
    }

}

