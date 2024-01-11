using MyVideoGames.WPFUI.Windows.ViewModels.Interface;

namespace MyVideoGames.WPFUI.Windows
{
    // Logique de la fenêtre
    // Injection du viewModel associé
    // Initialisation des éléments et du datacontext (le viewModel)
    public partial class MainWindow
    {
        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            DataContext = mainWindowViewModel;
        }
    }
}