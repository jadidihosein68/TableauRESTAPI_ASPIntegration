using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TableauRestAPI.Startup))]
namespace TableauRestAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
