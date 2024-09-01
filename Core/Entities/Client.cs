namespace LocadoraDigital.Core.Entities
{
    public class Client
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phone;
        private string _password;
        private string _address;
        private List<ConsoleUsageByClient> _usages;
        private List<Rental> _rentals;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
        public string Password { get => _password; set => _password = value; }
        public List<ConsoleUsageByClient> Usages { get => _usages; set => _usages = value; }
        public List<Rental> Rentals { get => _rentals; set => _rentals = value; }
    }
}
