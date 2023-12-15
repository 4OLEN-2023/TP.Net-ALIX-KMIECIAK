using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyVideoGames.WPFUI.Commands
{
    // Classe permettant d'éxécuter une commande de manière asynchrone
    // Afin de pouvoir gérer proprement les événements sans blocage
    // Cela pour éviter les conflits et les réposnes
    // Classe récupérée via le repo exposant des bonnes pratiques :
    // https://gist.github.com/dimitrispaxinos/f051d67a287bb34947a5
    // (Facultatif)
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<Task> _execute;

        private readonly Action<object> _executeParam;

        private readonly Predicate<object> _canExecute;

        private bool _isExecuting;

        // Constructeurs
        public RelayCommandAsync(Func<Task> execute) : this(execute, null)
        { }

        public RelayCommandAsync(Action<object> executeParam)
        {
            _executeParam = executeParam;
        }

        public RelayCommandAsync(Func<Task> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (!_isExecuting && _canExecute == null)
            {
                return true;
            }

            return !_isExecuting && _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            _isExecuting = true;

            try
            {
                if (_execute != null)
                {
                    await _execute();
                }
                else
                {
                    _executeParam(parameter);
                }
            }
            finally
            {
                _isExecuting = false;
            }
        }
    }
}