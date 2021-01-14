using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCodeFastProject_Alamgir.Startup))]
namespace MvcCodeFastProject_Alamgir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
