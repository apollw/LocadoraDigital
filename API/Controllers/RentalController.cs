using LocadoraDigital.Application.DTOs;
using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDigital.API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class RentalController : ControllerBase
    //{
    //    private readonly IRentalService _rentalService;

    //    public RentalController(IRentalService rentalService)
    //    {
    //        _rentalService = rentalService;
    //    }

    //    [HttpPost]
    //    public IActionResult CreateRental([FromBody] ClientDTO clientDto)
    //    {
    //        // Mapeamento do DTO para a entidade
    //        var client = new Client
    //        {
    //            Id = clientDto.Id,
    //            Name = clientDto.Name,
    //            Email = clientDto.Email,
    //            Address = clientDto.Address
    //        };

    //        var rental = _rentalService.CreateRental(client);

    //        var rentalDto = new RentalDTO
    //        {
    //            Id = rental.Id,
    //            ClientId = rental.Client.Id,
    //            Date = rental.Date,
    //            Items = rental.Items.Select(item => new RentalItemDTO
    //            {
    //                GameId = item.Game.Id,
    //                PlatformId = item.Platform.Id,
    //                Days = item.Days,
    //                Cost = item.Game.GetRentalPrice(item.Platform) * item.Days
    //            }).ToList(),
    //            TotalCost = rental.Items.Sum(item => item.Game.GetRentalPrice(item.Platform) * item.Days)
    //        };

    //        return Ok(rentalDto);
    //    }

    //    [HttpPost("{rentalId}/games")]
    //    public IActionResult AddGameToRental(int rentalId, [FromBody] GameRentalDTO gameRentalDto)
    //    {
    //        // Obtenha a locação existente (isso requer o repositório implementado)
    //        var rental = _rentalService.GetRentalById(rentalId); // Assumindo que esse método foi implementado

    //        if (rental == null)
    //        {
    //            return NotFound("Rental not found");
    //        }

    //        // Obtenha o jogo e a plataforma (isso requer o repositório implementado)
    //        var game = _rentalService.GetGameById(gameRentalDto.GameId); // Assumindo que esse método foi implementado

    //        if (game == null)
    //        {
    //            return NotFound("Game not found");
    //        }

    //        var platform = game.Platforms.FirstOrDefault(p => p.Id == gameRentalDto.PlatformId);
    //        if (platform == null)
    //        {
    //            return BadRequest("Game is not available on the selected platform.");
    //        }

    //        _rentalService.AddGameToRental(rental, game, platform, gameRentalDto.Days);

    //        return NoContent();
    //    }

    //    [HttpGet("{rentalId}/total-cost")]
    //    public IActionResult CalculateTotalCost(int rentalId)
    //    {
    //        var rental = _rentalService.GetRentalById(rentalId);

    //        if (rental == null)
    //        {
    //            return NotFound("Rental not found");
    //        }

    //        var totalCost = _rentalService.CalculateTotalCost(rental);

    //        return Ok(new { TotalCost = totalCost });
    //    }
    //}
}

