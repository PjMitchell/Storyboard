using System;
using System.Web.Mvc;

namespace Storyboard.Web.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
