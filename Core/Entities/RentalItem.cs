using LocadoraDigital.Core.Strategies;

namespace LocadoraDigital.Core.Entities
{
    public class RentalItem
    {
        private int _days;
        private int _quantity;
        private int _rentalId;
        private Rental _rental;
        private Game _game;
        private ConsoleDevice _consoleDevice;

        public int Days { get => _days; set => _days = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int RentalId { get => _rentalId; set => _rentalId = value; }
        public Rental Rental { get => _rental; set => _rental = value; }
        public Game Game { get => _game; set => _game = value; }
        public ConsoleDevice ConsoleDevice { get => _consoleDevice; set => _consoleDevice = value; }

        public IPriceStrategy PriceStrategy { get; set; } = new StandardPriceStrategy(); 
        public decimal CalculatePrice()
        {
            return PriceStrategy.CalculatePrice(Game, Days, ConsoleDevice) * Quantity;
        }
    }
}
