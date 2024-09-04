using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDigital.ViewModels
{
    public class AccessoryViewModel
    {
        public string Name { get; set; }
        public int ConsoleId { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> Consoles { get; set; }
    }
}
