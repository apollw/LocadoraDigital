using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Factories
{
    public class GamePlatformFactory : IFactoryService<GamePlatformTable>
    {
        public GamePlatformTable Create(int gameId, int platformId, decimal dailyPrice)
        {
            return new GamePlatformTable
            {
                GameId = gameId,
                PlatformId = platformId,
                DailyPrice = dailyPrice
            };
        }

        public GamePlatformTable Create()
        {
            return new GamePlatformTable
            {

            };
        }
    }
}
