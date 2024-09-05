using LocadoraDigital.Core.Interfaces.OutputPorts;
using LocadoraDigital.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Core.Strategies;

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
        public async Task<RentalTable> RentGamesAsync(int clientId, List<RentalItem> rentalItems)
        {
            // Verifica se o cliente existe
            var clientTable = await _clientService.GetClientByIdAsync(clientId);

            Client client = new Client
            {
                Id       = clientTable.Id,
                Name     = clientTable.Name,
                Phone    = clientTable.Phone,
                Email    = clientTable.Email,
                Usages   = clientTable.Usages,
                Rentals  = clientTable.Rentals,
                Address  = clientTable.Address,
                Password = clientTable.Password
            };

            // Inicializa um novo aluguel
            var rentalTable = new RentalTable
            {
                ClientId = clientId,
                Client   = client,
                Date     = DateTime.Now,
                Items    = new List<RentalItem>()
            };

            // Processa cada item do aluguel
            foreach (var item in rentalItems)
            {
                // Verifica se o jogo e o console existem
                var gameTable          = await _gameService.GetGameByIdAsync(item.Game.Id);
                var consoleDeviceTable = await _consoleDeviceService.GetConsoleDeviceByIdAsync(item.ConsoleDevice.Id);

                if (gameTable == null || consoleDeviceTable == null)
                {
                    throw new Exception("Jogo ou console não encontrados");
                }

                Game game = new Game
                {
                    Id        = gameTable.Id,
                    Title     = gameTable.Title,
                    Platforms = gameTable.Platforms
                };

                ConsoleDevice consoleDevice = new ConsoleDevice
                {
                    Id           = consoleDeviceTable.Id,
                    Name         = consoleDeviceTable.Name,
                    Usages       = consoleDeviceTable.Usages,
                    Platform     = consoleDeviceTable.Platform,
                    PlatformId   = consoleDeviceTable.PlatformId,
                    Accessories  = consoleDeviceTable.Accessories,
                    PricePerHour = consoleDeviceTable.PricePerHour
                };

                item.PriceStrategy = new StandardPriceStrategy(); 
                // Cria o item de aluguel e adiciona ao aluguel
                var rentalItem = new RentalItem
                {
                    Game          = game,
                    Days          = item.Days,
                    Quantity      = item.Quantity,
                    ConsoleDevice = consoleDevice,
                    PriceStrategy = item.PriceStrategy
                };

                rentalTable.Items.Add(rentalItem);
            }

            // Salva o aluguel e os itens associados no banco de dados
            await _rentalService.AddRentalAsync(rentalTable);

            // Retorna o aluguel criado
            return rentalTable;
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
