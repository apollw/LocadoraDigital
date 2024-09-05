using LocadoraDigital.Core.Entities;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Interfaces.InputPorts
{
    public interface IRentalService
    {
        Task AddRentalAsync(RentalTable rental);
        Task<RentalTable> GetRentalByIdAsync(int id);
        Task<IEnumerable<RentalTable>> GetAllRentalsAsync();
        Task DeleteRentalAsync(int id);
        Task UpdateRentalAsync(RentalTable client);

        //Métodos para itens do aluguel específico
        Task AddRentalItemAsync(RentalItemTable rentalItem);

    }
}
