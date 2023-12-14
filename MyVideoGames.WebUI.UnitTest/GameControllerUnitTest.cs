using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.DataContext;
using MyVideoGames.WebUI.Controllers;
using MyVideoGames.WebUI.Models;
using MyVideoGames.Model;

namespace MyVideoGames.WebUI.UnitTest
{
    public class GameControllerUnitTest
    {
        [Fact]
        public void ControllerShouldRun()
        {
            // Test de la récupération d'un controller GameController
            var controller = this.CreateController(0);
            Assert.NotNull(controller);
        }

        [Fact]
        public void ShouldDisplaySetListOfGames()
        {
            // Test : récupération d'éléments
            int nbItems = 2;

            // Méthode pour initialiser une instance de controller
            // Et simulation de l'affichage de la vue index
            var result = this.CreateController(nbItems).Index();

            // Test du ViewResult envoyé é la vue
            var viewResult = Assert.IsType<ViewResult>(result);
            // Test du type de model
            var model = Assert.IsAssignableFrom<GameListViewModel>(viewResult.ViewData.Model);

            // Test de la présence de jeux
            Assert.True(model.Games.Any());
        }

        /// <summary>
        /// Méthode de récupération d'un controller
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private GameController CreateController(int size = 0)
        {
            // using var context = new MainDbContext(contextBuilder.Options);

            // Mock d'une fausse configuration
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"DescMaxRow", "1"},
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            // Méthode créant un context
            var context = this.GetNewDBContext();
            // Méthode pour générer des données
            this.SeedData(size, context);

            // Création du service
            GameDataProvider gameService = new GameDataProvider(context);

            var controller = new GameController(gameService);

            return controller;
        }

        /// <summary>
        /// Génération de fausses données (nombre de données passé en paramétre)
        /// </summary>
        /// <param name="size"></param>
        /// <param name="context"></param>
        private void SeedData(int size, MainDbContext context)
        {
            context.Platforms.Add(new Platform
            {
                Name = $"PlaformTest",
            });

            // Ajout de fausses données
            for (int i = 0; i < size; i++)
            {
                context.Games.Add(new Game()
                {
                    Name = $"Jeu {i}",
                    PlatformId = 1,
                    Description = "test",
                    Slug="test"
                });
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Création d'un contexte
        /// </summary>
        /// <returns></returns>
        private MainDbContext GetNewDBContext()
        {
            // Création d'un nouveau context
            var contextBuilder = new DbContextOptionsBuilder<MainDbContext>();

            // Configuration d'une base de données en mémoire pour ne pas polluer la base de données
            contextBuilder.UseInMemoryDatabase(databaseName: "GameDatabase");

            return new MainDbContext(contextBuilder.Options);
        }

        /// <summary>
        /// Fin des tests
        /// </summary>
        public void Dispose()
        {
        }
    }
}