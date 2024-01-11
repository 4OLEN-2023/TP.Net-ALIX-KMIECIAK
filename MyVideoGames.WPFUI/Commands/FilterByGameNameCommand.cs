using MyVideoGames.Model;
using MyVideoGames.Service;
using MyVideoGames.WPFUI.Commands;
using MyVideoGames.WPFUI.Windows.ViewModels.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyVideoGames.WPFUI.Windows.ViewModels
{
    // Déclaration du ViewModel (partiel car nous définissons une autre partie ailleurs par soucis de découpage, properté)
    // Voir ViewModels/MainWindowViewModel.cs autre définition partielle du ViewModel Main contenant les propriétés et Bindings
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        // Délaration privée d'une commande (pour gestion interne)
        private ICommand _filterByGameNameCommand;

        // Déclaration public de la commande, liée au bouton dans "MainWindow.xaml)
        // Initialisation si null avec la tache associée à la commande "ExecuteFilterByGameNameCommand" et vérification (CanExecute)..
        // Afin de vérifier la donnée en entrée
        public ICommand FilterByGameNameCommand =>
            _filterByGameNameCommand ??= new RelayCommandAsync(ExecuteFilterByGameNameCommand, _ => CanExecuteFilterByGameNameCommand(_gameName));

        // Méthode de vérirication des données, return false et blocage si les confiditions décrites ci dessous sont pas bonnes
        private static bool CanExecuteFilterByGameNameCommand(string gameName)
        {
            // Vérification de la présence d'un gameName utile à la recherche
            return !string.IsNullOrWhiteSpace(gameName);
        }

        // Tache liée à la commande
        // Recherche d'un jeu dans la base de données
        private async Task ExecuteFilterByGameNameCommand()
        {
            // Appel du service afin de récupérer une liste de jeu dont le nom contient la saisie de l'utilisateur
            // _gameName provient de l'autre partie (patial) du viewModel
            // Voir ViewModels/MainWindowViewModel.cs
            IEnumerable<Game> searchResult = _gameDataProvider.SearchGamesByName(_gameName);

            // Si nous avons un résultat
            // Alors remplissage de la propriété "GameList" du ViewModel, liée, bindée à la vue
            // Déclanchant la mise à jour de l'affichge
            // Passage du flag de visibilité à true
            if (searchResult.Any())
            {
                GameList = new ObservableCollection<GameListItemViewModel>(searchResult.Select(x =>
                    new GameListItemViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = string.IsNullOrEmpty(x.Description) ? "" : x.Description,
                        ReleaseDate = x.ReleaseDate,
                        Rating = x.Rating
                    }));
                ShowGrid = true;
            }
            // Si pas de résultat, alors on vide la propriété "GameList" et passage du flag de visibilité à false
            else
            {
                GameList = new ObservableCollection<GameListItemViewModel>();
                ShowGrid = false;
            }
        }
    }
}