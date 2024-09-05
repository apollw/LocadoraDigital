using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.Strategies
{
    public interface IPriceStrategy
    {
        decimal CalculatePrice(Game game, int days, ConsoleDevice consoleDevice);
    }

}
