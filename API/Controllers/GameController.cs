using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDigital.API.Controllers
{
    public class GameController : Controller
    {
        private readonly IFactoryService<GameTable> _gameFactory;
        private readonly IGameService _gameService;

        public GameController(IFactoryService<GameTable> gameFactory, IGameService gameService)
        {
            _gameFactory = gameFactory;
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var game = _gameFactory.Create();
                game.Title = model.Title;       
                // Configure o restante das propriedades do jogo aqui conforme necessário

                // Supondo que você tenha um serviço para adicionar o jogo ao banco de dados
                await _gameService.AddGameAsync(game);

                ViewBag.Message = "Jogo adicionado!";
                return View();
            }

            return View(model);
        }
    }
}
