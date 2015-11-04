using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatalogManager.Startup))]
namespace CatalogManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
