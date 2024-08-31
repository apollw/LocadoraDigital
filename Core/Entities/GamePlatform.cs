namespace LocadoraDigital.Core.Entities
{
    public class GamePlatform
    {
        private decimal _dailyPrice;
        private int _gameId;
        private Game _game;
        private int _platformId;
        private Platform _platform;

        public decimal DailyPrice { get => _dailyPrice; set => _dailyPrice = value; }
        public int GameId { get => _gameId; set => _gameId = value; }
        public Game Game { get => _game; set => _game = value; }
        public int PlatformId { get => _platformId; set => _platformId = value; }
        public Platform Platform { get => _platform; set => _platform = value; }
    }
}
