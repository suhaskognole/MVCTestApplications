using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConstrustionAnalyser.Startup))]
namespace ConstrustionAnalyser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
