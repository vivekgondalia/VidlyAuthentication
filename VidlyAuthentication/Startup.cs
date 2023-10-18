using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyAuthentication.Startup))]
namespace VidlyAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
