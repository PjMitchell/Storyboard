using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Storyboard.Web.Startup))]
namespace Storyboard.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
