using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interfaces;

namespace MyVideoGames.WebUI.ExtensionMethods;

public static class ServicesExtensionMethods
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IGameDataProvider, GameDataProvider>();

        return services;
    }
}