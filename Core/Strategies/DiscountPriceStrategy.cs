using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.Strategies
{
    public class DiscountPriceStrategy : IPriceStrategy
    {
        public decimal CalculatePrice(Game game, int days, ConsoleDevice consoleDevice)
        {
            var basePrice = game.GetRentalPrice(consoleDevice.Platform);
            var discount = 0.1m; // 10% de desconto
            return (basePrice * days) * (1 - discount);
        }
    }
}
