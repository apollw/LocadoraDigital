using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDigital.API.Controllers
{
    public class AccessoryController : Controller
    {
        private readonly IAccessoryService _accessoryService;
        private readonly IConsoleDeviceService _consoleDeviceService;

        public AccessoryController(IAccessoryService accessoryService, IConsoleDeviceService consoleDeviceService)
        {
            _accessoryService = accessoryService;
            _consoleDeviceService = consoleDeviceService;
        }

        private async Task<IEnumerable<SelectListItem>> GetConsoleSelectListAsync()
        {
            var consoles = await _consoleDeviceService.GetAllConsoleDevicesAsync();

            return consoles.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAccessory()
        {
            var model = new AccessoryViewModel
            {
                Consoles = await GetConsoleSelectListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessory(AccessoryViewModel model)
        {
            var accessory = new AccessoryTable
            {
                Name = model.Name,
                ConsoleId = model.ConsoleId
            };

            await _accessoryService.AddAccessoryAsync(accessory);

            ViewBag.Message = "Acessório adicionado!";
            return RedirectToAction("CreateAccessory");
        }
    }
}
