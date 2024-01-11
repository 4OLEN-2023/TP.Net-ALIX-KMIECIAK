using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyVideoGames.WPFUI.Windows;
using MyVideoGames.WPFUI.Windows.ViewModels.Interface;
using MyVideoGames.DataContext;
using MyVideoGames.Service.Interfaces;
using MyVideoGames.Service;
using MyVideoGames.WPFUI.Windows.ViewModels;

namespace MyVideoGames.WPFUI.ExtensionMethods
{
    // Classe pour ranger l'injection de dépendances
    public static class ServicesExtensionMethods
    {
        // Méthode d'extension afin de gérer l'injection de dépendances, des services
        // Passage de la configuration en paramètre
        public static IServiceCollection AddInjectionDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Récupération de la chaine de connexion via la configuration
            string connectionString = configuration.GetConnectionString("GameDatabase");
            // Ajout du contexte de base de donnée
            // Utilisation du provider SQLServer
            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString, options => { });
            });

            // Déclaration de l'injection des Services
            services.AddScoped<IGameDataProvider, GameDataProvider>();

            // Déclaration de l'injection des Windows
            services.AddSingleton<MainWindow>();

            // Déclaration de l'injection des ViewModels
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();

            return services;
        }
    }
}