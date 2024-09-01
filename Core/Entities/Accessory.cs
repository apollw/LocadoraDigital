namespace LocadoraDigital.Core.Entities
{
    public class Accessory
    {
        private int _id;
        private string _name;
        private int _consoleId;
        private ConsoleDevice _console;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int ConsoleId { get => _consoleId; set => _consoleId = value; }
        public ConsoleDevice Console { get => _console; set => _console = value; }
    }
}
