using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccentureAcademyLibrary.Startup))]
namespace AccentureAcademyLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
