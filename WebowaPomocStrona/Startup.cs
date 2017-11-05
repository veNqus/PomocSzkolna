using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebowaPomocStrona.Startup))]
namespace WebowaPomocStrona
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
