using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jacobson.Web.Startup))]
namespace Jacobson.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
