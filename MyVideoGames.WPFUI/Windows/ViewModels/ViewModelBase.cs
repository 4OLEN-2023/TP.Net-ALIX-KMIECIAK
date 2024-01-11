using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoGames.WPFUI.Windows.ViewModels
{
    // ViewModel de base qui sera hérité à tout les ViewModel
    // Définition des attributs,  méthodes communes
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Event indiquant qu'une propriété du ViewModel a changé
        public event PropertyChangedEventHandler PropertyChanged;

        // Lorsque qu'une propriété change, propager l'événnement afin de potentiellement mettre à jour l'interface
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (name != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}