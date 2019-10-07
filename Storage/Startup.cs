using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Storage.Startup))]
namespace Storage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
