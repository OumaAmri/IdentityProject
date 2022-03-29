using IdentityProject.Areas.Identity.Data;
using IdentityProject.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Areas
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsingIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityProjectContext>();
            });
        }
    }
}
