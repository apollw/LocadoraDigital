using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("RentalItem")]
    public class RentalItemTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int Days { get; set; }

        [NotNull]
        public int Quantity { get; set; }

        // Chave estrangeira para a tabela Rental
        public int RentalId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public Rental Rental { get; set; }

        // Chave estrangeira para a tabela Game
        public int GameId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public Game Game { get; set; }

        // Chave estrangeira para a tabela ConsoleDevice
        public int ConsoleDeviceId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public ConsoleDevice ConsoleDevice { get; set; }
    }
}
