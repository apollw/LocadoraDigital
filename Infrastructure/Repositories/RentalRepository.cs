using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.OutputPorts;

namespace LocadoraDigital.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        // Assuming a DbContext or similar data access object for demonstration purposes.
        //private readonly DbContext _context;

        //public RentalRepository(DbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<Rental> GetByIdAsync(int id)
        //{
        //    return await _context.Rentals.FindAsync(id);
        //    return new Rental();
        //}

        //public async Task<IEnumerable<Rental>> GetAllAsync()
        //{
        //    return await _context.Rentals.ToListAsync();
        //}

        //public async Task AddAsync(Rental rental)
        //{
        //    _context.Rentals.Add(rental);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(Rental rental)
        //{
        //    _context.Rentals.Update(rental);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var rental = await GetByIdAsync(id);
        //    if (rental != null)
        //    {
        //        _context.Rentals.Remove(rental);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
