using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmazingRace.Startup))]
namespace AmazingRace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
