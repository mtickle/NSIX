using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NSIX.Startup))]
namespace NSIX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
