namespace LocadoraDigital.Core.Entities
{
    public class Rental
    {
        private int _id;
        private DateTime _date;
        private List<RentalItem> _items;
        private int _clientId;
        private Client _client;

        public int Id { get => _id; set => _id = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public List<RentalItem> Items { get => _items; set => _items = value; }
        public int ClientId { get => _clientId; set => _clientId = value; }
        public Client Client { get => _client; set => _client = value; }
    }
}
