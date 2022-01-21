using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EfExample2.Startup))]
namespace EfExample2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
