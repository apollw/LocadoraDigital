namespace LocadoraDigital.Application.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> PlatformIds { get; set; }
    }
}
