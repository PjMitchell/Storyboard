using Storyboard.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storyboard.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View(this.CreateViewModel());
        }

        [Authorize]
        public ActionResult App()
        {
            return View(this.CreateViewModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(this.CreateViewModel());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(this.CreateViewModel());
        }
    }
}