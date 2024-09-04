using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDigital.ViewModels
{
    public class GameViewModel
    {
        public string Title { get; set; }
        public int ConsoleDeviceId { get; set; }

        // Lista de ConsoleDevices para o dropdown
        public IEnumerable<SelectListItem> ConsoleDevices { get; set; }
    }
}


