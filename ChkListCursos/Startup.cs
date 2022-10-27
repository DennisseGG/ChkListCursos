using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChkListCursos.Startup))]
namespace ChkListCursos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
