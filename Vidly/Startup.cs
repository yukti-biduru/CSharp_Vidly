using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_with_Individual_Authentication.Startup))]
namespace Vidly_with_Individual_Authentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
