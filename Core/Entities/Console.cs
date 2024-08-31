namespace LocadoraDigital.Core.Entities
{
    public class Console
    {
        private int _id;
        private string _name;
        private decimal _pricePerHour;
        private int _platformId;
        private Platform _platform;
        private List<Accessory> _accessories;
        private List<ConsoleUsageByClient> _usages;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal PricePerHour { get => _pricePerHour; set => _pricePerHour = value; }
        public int PlatformId { get => _platformId; set => _platformId = value; }
        public Platform Platform { get => _platform; set => _platform = value; }
        public List<Accessory> Accessories { get => _accessories; set => _accessories = value; }
        public List<ConsoleUsageByClient> Usages { get => _usages; set => _usages = value; }
    }
}
