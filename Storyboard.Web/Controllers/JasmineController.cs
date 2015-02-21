using System;
using System.Web.Mvc;

namespace Storyboard.Web.Controllers
{
    [Authorize]
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
