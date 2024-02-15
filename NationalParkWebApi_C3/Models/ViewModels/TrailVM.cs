using Microsoft.AspNetCore.Mvc.Rendering;
using NationalParkWebApi_C3.Models;

namespace NationalParkWebApi_C3.Models.ViewModels
{
    public class TrailVM
    {
        public Trail Trail { get; set; }
        public IEnumerable<SelectListItem> NationalParkList { get; set; }
    }
}
