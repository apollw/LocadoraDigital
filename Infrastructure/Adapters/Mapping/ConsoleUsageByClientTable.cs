using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("ConsoleUsageByClient")]
    public class ConsoleUsageByClientTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Chave estrangeira para a tabela ConsoleDevice
        public int ConsoleId { get; set; }

        // Chave estrangeira para a tabela Client
        public int ClientId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public ConsoleDevice Console { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public Client Client { get; set; }
    }
}
