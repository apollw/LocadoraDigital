namespace LocadoraDigital.Core.Entities
{
    public class Platform
    {
        private int _id;
        private string _name;
        private List<GamePlatform> _games;
        private List<Console> _consoles;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public List<GamePlatform> Games { get => _games; set => _games = value; }
        public List<Console> Consoles { get => _consoles; set => _consoles = value; }
    }
}
