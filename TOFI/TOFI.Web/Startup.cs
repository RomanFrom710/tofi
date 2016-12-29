using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TOFI.Web.Startup))]
namespace TOFI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Worker");
            Worker.Worker.Run();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
