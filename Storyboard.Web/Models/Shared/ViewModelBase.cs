using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Storyboard.Web.Models
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            SetUser(null);
        }
        
        public ViewModelBase(IPrincipal user)
        {
            SetUser(user);
        }
        public string Username { get; private set; }
        public bool IsLoggedIn { get; private set; }

        public void SetUser(IPrincipal user)
        {
            if (user == null)
            {
                IsLoggedIn = false;
                Username = string.Empty;
            }
            else
            {
                IsLoggedIn = user.Identity.IsAuthenticated;
                Username = user.Identity.Name;
            }
        }
    }
}