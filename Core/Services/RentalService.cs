using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Core.Interfaces.OutputPorts;

namespace LocadoraDigital.Core.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IGameRepository _gameRepository;

        public RentalService(IRentalRepository rentalRepository, IGameRepository gameRepository)
        {
            _rentalRepository = rentalRepository;
            _gameRepository = gameRepository;
        }

        public Rental CreateRental(Client client)
        {
            var rental = new Rental
            {
                Client = client,
                Date = DateTime.Now,
                Items = new List<RentalItem>()
            };

            //_rentalRepository.AddAsync(rental);
            return rental;
        }

        public void AddGameToRental(Rental rental, Game game, Platform platform, int days)
        {
            if (!game.IsAvailableOnPlatform(platform))
                throw new InvalidOperationException("Game is not available on the selected platform.");

            var rentalItem = new RentalItem
            {
                Game = game,
                Platform = platform,
                Days =days
            };

            rental.Items.Add(rentalItem);
            //_rentalRepository.UpdateAsync(rental);
        }

        public decimal CalculateTotalCost(Rental rental)
        {
            return rental.Items.Sum(item => item.Game.GetRentalPrice(item.Platform) * item.Days);
        }

        public Rental GetRentalById(int id)
        {
            return _rentalRepository .GetById(id);
        }

        public Game GetGameById(int id)
        {
            return _gameRepository.GetById(id);
        }
    }
}
