using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UI.Data;

namespace SecuringWebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services
                .AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));

            services
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApiDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddRazorPages(options =>
            //{
            //    options.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account", route =>
            //    {
            //        route.RouteValues["area"] = "Identity";
            //    });
            //});
        }
    }
}
