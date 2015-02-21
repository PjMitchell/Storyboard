using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storyboard.Web.Models
{
    public static class ControllerExtensions
    {
        public static ViewModelBase CreateViewModel(this Controller controller)
        {
            return controller.CreateViewModel<ViewModelBase>();
        }
        
        public static T CreateViewModel<T>(this Controller controller) where T : ViewModelBase, new()
        {
            var vm = new T();
            vm.SetUser(controller.User);
            return vm;
        }
    }
}