using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("Accessory")]
    public class AccessoryTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        // Chave estrangeira para a tabela ConsoleDevice
        public int ConsoleId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public ConsoleDevice ConsoleDevice { get; set; }
    }
}

