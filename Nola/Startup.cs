using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nola.Startup))]
namespace Nola
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
