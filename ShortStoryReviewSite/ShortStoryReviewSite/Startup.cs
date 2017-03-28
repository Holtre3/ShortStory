using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShortStoryReviewSite.Startup))]
namespace ShortStoryReviewSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
