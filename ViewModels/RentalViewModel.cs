using LocadoraDigital.Core.Entities;
using LocadoraDigital.ViewModels;

public class RentalViewModel
{
    public int SelectedClientId { get; set; }
    public List<RentalItemViewModel> RentalItems { get; set; } = new List<RentalItemViewModel>();

    public List<Game> AvailableGames { get; set; }
    public List<Client> Clients { get; set; }
        
    public List<int> SelectedGameIds { get; set; } = new List<int>();
    public int Days { get; set; }
}

public class RentalItemViewModel
{
    public int GameId { get; set; }
}

