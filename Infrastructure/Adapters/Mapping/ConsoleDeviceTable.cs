using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("ConsoleDevice")]
    public class ConsoleDeviceTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public decimal PricePerHour { get; set; }

        // Chave estrangeira para a tabela Platform
        public int PlatformId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public Platform Platform { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public List<Accessory> Accessories { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public List<ConsoleUsageByClient> Usages { get; set; }
    }
}
