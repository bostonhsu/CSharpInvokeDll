using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventorySearch.Startup))]
namespace InventorySearch
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
