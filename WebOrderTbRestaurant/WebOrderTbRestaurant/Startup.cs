using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebOrderTbRestaurant.Startup))]
namespace WebOrderTbRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
