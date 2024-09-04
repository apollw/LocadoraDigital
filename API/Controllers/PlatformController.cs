using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDigital.API.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public IActionResult CreatePlatform()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform(PlatformViewModel model)
        {
            if (ModelState.IsValid)
            {
                var platform = new PlatformTable
                {
                    Name = model.Name
                };

                await _platformService.AddPlatformAsync(platform);

                ViewBag.Message = "Plataforma adicionada!";
                return View();
            }

            return View(model);
        }

    }
}

