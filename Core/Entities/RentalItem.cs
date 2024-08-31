namespace LocadoraDigital.Core.Entities
{
    public class RentalItem
    {
        private int _days;
        private int _quantity;
        private int _rentalId;
        private Rental _rental;

        public int Days { get => _days; set => _days = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int RentalId { get => _rentalId; set => _rentalId = value; }
        public Rental Rental { get => _rental; set => _rental = value; }
    }
}
