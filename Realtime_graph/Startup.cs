using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Realtime_graph.Startup))]
namespace Realtime_graph
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
