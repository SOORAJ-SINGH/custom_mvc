using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomizationMvc.Startup))]
namespace CustomizationMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
