using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FetLife.AutoLogin.Startup))]
namespace FetLife.AutoLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
