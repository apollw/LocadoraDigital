using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDigital.API.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new ClientTable
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    Password = model.Password
                };

                await _clientService.AddClientAsync(client);

                ViewBag.Message = "Cliente adicionado!";
                return View();
            }

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

