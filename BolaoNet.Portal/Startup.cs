using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BolaoNet.Portal.Startup))]
namespace BolaoNet.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
