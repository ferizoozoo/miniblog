using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniBlog.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MiniBlog.Areas.Identity.IdentityHostingStartup))]
namespace MiniBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MiniBlogIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("MiniBlogIdentityDbContextConnectionTest")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MiniBlogIdentityDbContext>();
            });
        }
    }
}