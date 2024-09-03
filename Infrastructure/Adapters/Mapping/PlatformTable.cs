using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("Platform")]
    public class PlatformTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull, MaxLength(100)]
        public string Name { get; set; }

        // Propriedades de navegação (não mapeadas diretamente, mas usadas para relacionamentos em código)
        [Ignore]
        public List<GamePlatform> Games { get; set; }

        [Ignore]
        public List<ConsoleDevice> Consoles { get; set; }
    }
}
