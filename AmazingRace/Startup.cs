using Microsoft.Owin;
using Owin;
using AmazingRace.Hubs;

[assembly: OwinStartupAttribute(typeof(AmazingRace.Startup))]
namespace AmazingRace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            FileWatcher.init();
            app.MapSignalR();
        }
    }
}
