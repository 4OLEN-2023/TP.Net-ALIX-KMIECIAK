using Microsoft.EntityFrameworkCore;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interfaces;
using MyVideoGames.DataContext;

namespace MyVideoGames.WebUI.ExtensionMethods;

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

        return services;
    }
}