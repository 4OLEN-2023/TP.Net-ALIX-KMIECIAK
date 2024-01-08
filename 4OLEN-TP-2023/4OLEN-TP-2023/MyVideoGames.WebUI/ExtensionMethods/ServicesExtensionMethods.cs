using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interface;
using MyVideoGames.DataContext;

namespace MyVideoGames.WebUI.ExtensionMethods
{
    public static class ServicesExtensionMethods
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("GameDatabase");
            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString, options => { });
            });

            services.AddScoped<IGameDataProvider, GameDataProvider>();
            services.AddScoped<IPlatformDataProvider, PlatformDataProvider>();

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MainDbContext>();
            
            return services;
        }

    }
}