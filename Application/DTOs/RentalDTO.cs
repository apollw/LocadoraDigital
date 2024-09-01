namespace LocadoraDigital.Application.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public List<RentalItemDTO> Items { get; set; }
        public decimal TotalCost { get; set; }
    }
}
