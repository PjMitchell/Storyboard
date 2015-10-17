using Storyboard.Web.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Storyboard.Web.Models.Home;

namespace Storyboard.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel
            {
                IsSignedIn = User?.Identity?.IsAuthenticated ?? false
            };
            return View(vm);
        }

        [Authorize]
        public ActionResult App()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}