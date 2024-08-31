namespace LocadoraDigital.Core.Entities
{
    public class ConsoleUsageByClient
    {
        private int _id;
        private DateTime _start;
        private DateTime _end;
        private int _consoleId;
        private Console _console;
        private int _clientId;
        private Client _client;

        public int Id { get => _id; set => _id = value; }
        public DateTime Start { get => _start; set => _start = value; }
        public DateTime End { get => _end; set => _end = value; }
        public int ConsoleId { get => _consoleId; set => _consoleId = value; }
        public Console Console { get => _console; set => _console = value; }
        public int ClientId { get => _clientId; set => _clientId = value; }
        public Client Client { get => _client; set => _client = value; }
    }
}
