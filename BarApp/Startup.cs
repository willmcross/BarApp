using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarApp.Startup))]
namespace BarApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
