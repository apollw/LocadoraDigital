using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("GamePlatform")]
    public class GamePlatformTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public decimal DailyPrice { get; set; }

        // Chave estrangeira para a tabela Game
        [NotNull]
        public int GameId { get; set; }

        // Chave estrangeira para a tabela Platform
        [NotNull]
        public int PlatformId { get; set; }

        // Propriedades de navegação (não mapeadas diretamente, mas usadas para relacionamentos em código)
        [Ignore]
        public Game Game { get; set; }

        [Ignore]
        public Platform Platform { get; set; }
    }
}
