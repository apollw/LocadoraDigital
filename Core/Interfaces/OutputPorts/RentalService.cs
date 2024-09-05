using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;
using SQLite;

namespace LocadoraDigital.Core.Interfaces.OutputPorts
{
    public class RentalService : IRentalService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public RentalService(DatabaseConfig databaseConfig)
        {
            _dbConnection = databaseConfig.GetDbConnection();
        }
        
        public async Task AddRentalAsync(RentalTable rental)
        {
            await _dbConnection.InsertAsync(rental);
        }
        
        public async Task<RentalTable> GetRentalByIdAsync(int id)
        {
            return await _dbConnection.FindAsync<RentalTable>(id);
        }

        public async Task<IEnumerable<RentalTable>> GetAllRentalsAsync()
        {
            return await _dbConnection.Table<RentalTable>().ToListAsync();
        }
        
        public async Task DeleteRentalAsync(int id)
        {
            var rental = await _dbConnection.FindAsync<RentalTable>(id);
            if (rental != null)
            {
                await _dbConnection.DeleteAsync(rental);
            }
        }
        
        public async Task UpdateRentalAsync(RentalTable rental)
        {
            await _dbConnection.UpdateAsync(rental);
        }

        public async Task AddRentalItemAsync(RentalItemTable rentalItem)
        {
            await _dbConnection.InsertAsync(rentalItem);
        }
    }
}
