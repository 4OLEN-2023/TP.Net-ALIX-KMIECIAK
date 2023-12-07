using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interface;

namespace MyVideoGames.WebUI.ExtensionMethods
{
    public static class ServicesExtensionMethods
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IGameDataProvider, GameDataProvider>();

            return services;
        }

    }
}