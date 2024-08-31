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
    }
}
