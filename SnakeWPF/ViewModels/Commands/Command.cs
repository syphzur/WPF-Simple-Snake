using System;
using System.Windows.Input;

namespace SnakeWPF.ViewModels.Commands
{
    class Command : ICommand
    {
        private Action _action;
       //private Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            this._action = action;
            //this._canExecute = canExecute;

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
