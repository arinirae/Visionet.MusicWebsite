using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Visionet.MusicWebsite.Startup))]
namespace Visionet.MusicWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
