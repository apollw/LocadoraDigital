namespace LocadoraDigital.Application.DTOs
{
    public class RentalItemDTO
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public int Days { get; set; }
        public decimal Cost { get; set; }
    }
}
