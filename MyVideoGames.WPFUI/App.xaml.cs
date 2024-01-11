using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyVideoGames.WPFUI.ExtensionMethods;
using MyVideoGames.WPFUI.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyVideoGames.WPFUI
{
    /// <summary>
    /// Classe mère de l'application WPF
    /// Contructeur et initilialisation, gestion des éléments (Sartup, quit)
    /// </summary>
    public partial class App : Application
    {
        // Host (containeur de l'application)
        private readonly IHost _host;

        public App()
        {
            // Création du Host
            _host = new HostBuilder()
                 // Ajout de la configuration
                 .ConfigureAppConfiguration(builder =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                // Ajout de l'injection de dépendances
                .ConfigureServices((context, services) =>
                {
                    // Méthode gérant l'injection de dépendances
                    // Voir ExtensionMethods/ExtensionMethods.cs
                    services.AddInjectionDependencies(context.Configuration);
                })
                // Construction du Host de l'app
                .Build();
        }

        // Override de la méthode de démarrage
        protected override async void OnStartup(StartupEventArgs e)
        {
            // Démarrage du containeur applicatif
            await _host.StartAsync();

            // Récupération des éléments nécessaires à la Window via l'injection de dépendances
            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();

            // Vérification pour éviter un crash en cas d'erreur imbriquée
            if (mainWindow == null)
            {
                throw new ArgumentNullException(nameof(mainWindow), @"The value cannot be null!");
            }

            // Affichage de la première et principale fenêtre
            mainWindow.Show();

            // Appel du startup hérité pour démarrer les composants nécessaires via le Framework
            base.OnStartup(e);
        }

        // Override de la méthode de fin de vie
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                // Arrêt du Host de l'application
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}