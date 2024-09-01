using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IRentalService
    {
        Rental CreateRental(Client client);
        void AddGameToRental(Rental rental, Game game, Platform platform, int days);
        decimal CalculateTotalCost(Rental rental);
    }
}
