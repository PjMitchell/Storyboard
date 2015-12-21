using Microsoft.AspNet.Mvc;
using Storyboard.Web.Models;

namespace Storyboard.Web.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var vm = new HeaderViewModel();
            vm.Username = HttpContext.User?.Identity?.Name ?? string.Empty;
            vm.IsLoggedIn = !string.IsNullOrEmpty(vm.Username);
            return View(vm);
        }
    }
}
