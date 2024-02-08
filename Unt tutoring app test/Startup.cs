using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unt_tutoring_app_test.Startup))]
namespace Unt_tutoring_app_test
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
