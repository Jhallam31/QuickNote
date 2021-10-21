using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuickNote.Startup))]
namespace QuickNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
