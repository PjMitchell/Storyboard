using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Storyboard.Web.Models
{
    public class HeaderViewModel
    {
        public string Username { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}