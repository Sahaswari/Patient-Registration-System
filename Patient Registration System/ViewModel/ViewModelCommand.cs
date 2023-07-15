using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Patient_Registration_System.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //fields
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        //constructor
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public ViewModelCommand()
        {
        }

        //events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Predicate<object> Get_canExecuteAction()
        {
            return _canExecuteAction;
        }

        //methods
        public bool CanExecute(object parameter, Predicate<object> _canExecuteAction)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
