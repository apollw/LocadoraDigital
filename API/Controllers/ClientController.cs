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

        [HttpGet]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            // Converte ClientTable para ClientViewModel
            var model = new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone,
                Address = client.Address,
                Password = client.Password
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteClient(ClientTable model)
        {
            await _clientService.DeleteClientAsync(model.Id);
            ViewBag.Message = "Cliente removido!";
            return RedirectToAction("ListClients");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var model = new ClientViewModel
            {
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone,
                Address = client.Address,
                Password = client.Password
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new ClientTable
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    Password = model.Password
                };

                await _clientService.UpdateClientAsync(client);

                ViewBag.Message = "Cliente atualizado!";
                return RedirectToAction("ListClients");
            }

            return View(model);
        }

        public async Task<IActionResult> ListClients()
        {
            var clientTables = await _clientService.GetAllClientsAsync();
            var clientViewModels = clientTables.Select(c => new ClientViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address
            }).ToList();

            return View(clientViewModels);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

