using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDigital.ViewModels
{
    public class ConsoleDeviceViewModel
    {
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public int PlatformId { get; set; }

        // Lista de plataformas para o dropdown
        [BindNever]
        public IEnumerable<SelectListItem> Platforms { get; set; }
    }
}
