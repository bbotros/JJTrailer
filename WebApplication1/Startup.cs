using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JJTrailerStore.Startup))]
namespace JJTrailerStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
