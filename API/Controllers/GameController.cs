using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Core.Interfaces.OutputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDigital.API.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IConsoleDeviceService _consoleDeviceService;

        public GameController(IGameService gameService, IConsoleDeviceService consoleDeviceService)
        {
            _gameService = gameService;
            _consoleDeviceService = consoleDeviceService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateGame()
        {
            var consoleDevices = await _consoleDeviceService.GetAllConsoleDevicesAsync();

            var viewModel = new GameViewModel
            {
                ConsoleDevices = consoleDevices.Select(cd => new SelectListItem
                {
                    Value = cd.Id.ToString(),
                    Text = $"{cd.Name} - {cd.PricePerHour:C}"
                })
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateGame(GameViewModel model)
        {
            var consoleDevices = await _consoleDeviceService.GetAllConsoleDevicesAsync();

            if (ModelState.IsValid)
            {
                var game = new GameTable
                {
                    Title = model.Title
                };

                // Adiciona o jogo ao banco de dados
                await _gameService.AddGameAsync(game);

                // Adiciona os consoles associados ao jogo
                foreach (var consoleDevice in consoleDevices)
                {
                    var gamePlatform = new GamePlatformTable
                    {
                        GameId = game.Id,
                        PlatformId = consoleDevice.PlatformId,
                        DailyPrice = consoleDevice.PricePerHour
                    };

                    await _consoleDeviceService.AddGamePlatformAsync(gamePlatform);
                }

                ViewBag.Message = "Jogo adicionado com sucesso!";
                return RedirectToAction("CreateGame");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return View(games);
        }
    }
}
