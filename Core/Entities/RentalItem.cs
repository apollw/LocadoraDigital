namespace LocadoraDigital.Core.Entities
{
    public class RentalItem
    {
        private int _rentalId;
        private int _gameId;
        private Rental _rental;
        private Game _game;

        public int RentalId { get => _rentalId; set => _rentalId = value; }
        public Rental Rental { get => _rental; set => _rental = value; }
        public Game Game { get => _game; set => _game = value; }
        public int GameId { get => _gameId; set => _gameId = value; }
    }
}
