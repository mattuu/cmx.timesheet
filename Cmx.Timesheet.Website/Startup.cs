using System.Web.Mvc;
using Cmx.Timesheet.Website;
using Microsoft.Owin;
using Microsoft.Practices.Unity.Mvc;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Cmx.Timesheet.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.GetConfiguredContainer()));
        }
    }
}