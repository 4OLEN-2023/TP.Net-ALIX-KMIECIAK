using MyVideoGames.Service.Interfaces;
using MyVideoGames.WPFUI.Windows.ViewModels.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoGames.WPFUI.Windows.ViewModels
{
    // Déclaration du ViewModel (partiel car nous définissons une autre partie ailleurs par soucis de découpage, properté)
    // Voir Commands/FilterByGameNameCommand.cs autre définition partielle du ViewModel Main contenant les commands, interactions
    // Héritage du model de base afin de profiter des méthodes et attributs communs
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        // Stockage du service
        private readonly IGameDataProvider _gameDataProvider;

        // Constructeur avec injection de dépendances
        public MainWindowViewModel(IGameDataProvider gameDataProvider)
        {
            _gameDataProvider = gameDataProvider;
        }

        // Stockage de la valeur associée au Binding "GameName"
        private string _gameName;

        // Champ et Binding "GameName"
        // Récupération
        // Gestion des évenements en cas de modification
        // Voir liaison dans MainWindow.xaml
        public string GameName
        {
            get => _gameName;
            set
            {
                _gameName = value;

                OnPropertyChanged();
            }
        }

        // Stockage de la valeur associée au Binding "GameDesc"
        private string _gameDesc;

        // Champ et Binding "GameDesc"
        // Récupération
        // Gestion des évenements en cas de modification
        // Voir liaison dans MainWindow.xaml
        public string GameDesc
        {
            get => _gameDesc;
            set
            {
                _gameDesc = value;

                OnPropertyChanged();
            }
        }

        // Stockage de la Collection de GameListItemViewModel associée au champ/binding GameList
        private ObservableCollection<GameListItemViewModel> _gameList = new();

        // Champ et Binding "GameList"
        // Récupération
        // Gestion des évenements en cas de modification
        // Voir liaison dans MainWindow.xaml
        public ObservableCollection<GameListItemViewModel> GameList
        {
            get => _gameList;
            set
            {
                _gameList = value;

                OnPropertyChanged();
            }
        }

        // Valeur du flag gérant l'affichage ou non du tableau de résultats
        private bool _showGrid = false;

        // Champs et Binding "ShowGrid"
        // Récupération
        // Gestion des évenements en cas de modification
        // Voir liaison dans MainWindow.xaml
        public bool ShowGrid
        {
            get => _showGrid;
            set
            {
                _showGrid = value;

                OnPropertyChanged();
            }
        }

        // Champs et Binding "ShowNoResult" éxacte inverse de "ShowGrid"
        // Récupération en inversant showGrid
        // Voir liaison dans MainWindow.xaml
        public bool ShowNoResult
        {
            get => !_showGrid;
        }
    }
}