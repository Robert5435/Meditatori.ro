using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BeMyTeacher.Areas.Identity.IdentityHostingStartup))]
namespace BeMyTeacher.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}