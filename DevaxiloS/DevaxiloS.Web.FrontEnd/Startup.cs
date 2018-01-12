using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevaxiloS.Web.FrontEnd.Startup))]
namespace DevaxiloS.Web.FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
