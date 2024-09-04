using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDigital.API.Controllers
{
    public class ConsoleDeviceController : Controller
    {
        private readonly IConsoleDeviceService _consoleDeviceService;
        private readonly IPlatformService _platformService;

        public ConsoleDeviceController(IConsoleDeviceService consoleDeviceService, IPlatformService platformService)
        {
            _consoleDeviceService = consoleDeviceService;
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateConsoleDevice()
        {
            var model = new ConsoleDeviceViewModel
            {
                Platforms = await GetPlatformSelectListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsoleDevice(ConsoleDeviceViewModel model)
        {
             var consoleDevice = new ConsoleDeviceTable
             { 
                 Name = model.Name,
                 PricePerHour = model.PricePerHour,
                 PlatformId = model.PlatformId
             };

             await _consoleDeviceService.AddConsoleDeviceAsync(consoleDevice);

             ViewBag.Message = "Console adicionado!";
             return RedirectToAction("CreateConsoleDevice");
        }

        private async Task<IEnumerable<SelectListItem>> GetPlatformSelectListAsync()
        {
            var platforms = await _platformService.GetAllPlatformsAsync();

            return platforms.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        }
    }
}
