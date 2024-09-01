using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.OutputPorts;

namespace LocadoraDigital.Infrastructure.Adapters.Persistence
{
    public class RentalRepository : IRentalRepository
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public Rental GetById(int id)
        {
            return _rentals.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Rental> GetAll()
        {
            return _rentals;
        }

        public void Add(Rental rental)
        {
            _rentals.Add(rental);
        }

        public void Update(Rental rental)
        {
            var existingRental = GetById(rental.Id);
            if (existingRental != null)
            {
                // Assuming you want to replace the whole rental
                _rentals.Remove(existingRental);
                _rentals.Add(rental);
            }
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            if (rental != null)
            {
                _rentals.Remove(rental);
            }
        }
    }
}

