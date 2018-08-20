using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BancoSowConnect.Apresentation.Web.Startup))]
namespace BancoSowConnect.Apresentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
