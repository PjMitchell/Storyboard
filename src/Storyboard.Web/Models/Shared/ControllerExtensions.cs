using Microsoft.AspNet.Mvc;

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

        public static ViewResult ViewWithBaseViewModel(this Controller controller)
        {
            return controller.View(controller.CreateViewModel<ViewModelBase>());
        }
    }
}