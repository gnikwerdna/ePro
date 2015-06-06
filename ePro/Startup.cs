using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ePro.Startup))]
namespace ePro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
