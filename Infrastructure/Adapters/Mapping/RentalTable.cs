using LocadoraDigital.Core.Entities;
using SQLite;

namespace LocadoraDigital.Infrastructure.Adapters.Mapping
{
    [Table("Rental")]
    public class RentalTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public DateTime Date { get; set; }

        // Chave estrangeira para a tabela Client
        public int ClientId { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public Client Client { get; set; }

        // Propriedade de navegação (não mapeada diretamente, mas usada para relacionamentos em código)
        [Ignore]
        public List<RentalItem> Items { get; set; }
    }
}
