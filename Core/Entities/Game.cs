namespace LocadoraDigital.Core.Entities
{
    public class Game
    {
        private int _id;
        private string _title;
        private List<GamePlatform> _platforms;

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public List<GamePlatform> Platforms { get => _platforms; set => _platforms = value; }

        public bool IsAvailableOnPlatform(Platform platform)
        {
            return Platforms.Any(gp => gp.PlatformId == platform.Id);
        }

        public decimal GetRentalPrice(Platform platform)
        {
            var gamePlatform = Platforms.FirstOrDefault(gp => gp.PlatformId == platform.Id);
            return gamePlatform?.DailyPrice ?? 0m;
        }
    }
}
