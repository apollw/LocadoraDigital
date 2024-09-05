using LocadoraDigital.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Web.Controllers
{
    public class RentalController : Controller
    {
        private readonly IGameService   _gameService;
        private readonly IRentalService _rentalService;
        private readonly IClientService _clientService;
        private readonly IConsoleDeviceService _consoleDeviceService;

        public RentalController(
            IGameService gameService,
            IRentalService rentalService,
            IClientService clientService,
            IConsoleDeviceService consoleDeviceService)
        {
            _gameService = gameService;
            _rentalService = rentalService;
            _clientService = clientService;
            _consoleDeviceService = consoleDeviceService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateRental()
        {
            // Obtém as tabelas de dados
            IEnumerable<GameTable> gamesTable     = await _gameService.GetAllGamesAsync();
            IEnumerable<ClientTable> clientsTable = await _clientService.GetAllClientsAsync();

            var availableGames = gamesTable;

            // Mapeie as tabelas para entidades
            var games   = gamesTable.Select(MapToGame).ToList();
            var clients = clientsTable.Select(MapToClient).ToList();

            // Crie o ViewModel e preencha os dados
            var viewModel = new RentalViewModel
            {
                Clients        = clients,
                AvailableGames = games
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(RentalViewModel viewModel)
        {
            // Verifica se o cliente existe
            var clientTable = await _clientService.GetClientByIdAsync(viewModel.SelectedClientId);
            var gamePlatformList = await _consoleDeviceService.GetAllGamePlatformsAsync();
            gamePlatformList.ToList();

            Client client = new Client
            {
                Id = clientTable.Id,
                Name = clientTable.Name,
                Phone = clientTable.Phone,
                Email = clientTable.Email,
                Usages = clientTable.Usages,
                Rentals = clientTable.Rentals,
                Address = clientTable.Address,
                Password = clientTable.Password
            };

            // Inicializa um novo aluguel
            var rentalTable = new RentalTable
            {
                ClientId = viewModel.SelectedClientId,
                Client   = client,
                Date     = DateTime.Now,
                Items    = new List<RentalItem>()
            };

            decimal gamePrice;
            decimal totalPrice = 0;

            // Processa os jogos selecionados
            foreach (var gameId in viewModel.SelectedGameIds)
            {
                var gameTable = await _gameService.GetGameByIdAsync(gameId);
                Game game = new Game
                {
                    Id = gameTable.Id,
                    Title = gameTable.Title,
                    Platforms = gameTable.Platforms
                };               

                foreach(var item in gamePlatformList)
                {
                    if (item.GameId == gameTable.Id)
                    {
                        gamePrice  = item.DailyPrice;
                        totalPrice = totalPrice + gamePrice;
                    }
                }                

                // Criando item de aluguel
                var rentalItem = new RentalItem
                {
                    GameId   = game.Id,
                    RentalId = rentalTable.Id                   
                };

                // Criando item table de aluguel
                var rentalItemTable = new RentalItemTable
                {
                    GameId   = game.Id,
                    RentalId = rentalTable.Id
                };

                rentalTable.Items.Add(rentalItem);
                await _rentalService.AddRentalItemAsync(rentalItemTable);
            }

            //Preço total da transação
            totalPrice = totalPrice*viewModel.Days;

            // Atribui o preço total ao ViewModel para ser mostrado na View
            ViewBag.TotalPrice = totalPrice;

            // Salva o aluguel no banco de dados
            await _rentalService.AddRentalAsync(rentalTable);

            return View(viewModel);
        }

        public static Client MapToClient(ClientTable clientTable)
        {
            return new Client
            {
                Id = clientTable.Id,
                Name = clientTable.Name
            };
        }

        public static Game MapToGame(GameTable gameTable)
        {
            return new Game
            {
                Id = gameTable.Id,
                Title = gameTable.Title
            };
        }
        
    }
}
