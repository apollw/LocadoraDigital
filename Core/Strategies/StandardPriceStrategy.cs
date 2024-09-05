using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.Strategies
{
    public class StandardPriceStrategy : IPriceStrategy
    {
        public decimal CalculatePrice(Game game, int days, ConsoleDevice consoleDevice)
        {
            var basePrice = game.GetRentalPrice(consoleDevice.Platform);
            return basePrice * days;
        }
    }
}
