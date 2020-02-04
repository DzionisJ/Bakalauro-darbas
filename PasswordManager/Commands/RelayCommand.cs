using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.Commands
{
    class RelayCommand : ICommand
    {
        private Action<object> execute_command;
        private Func<object, bool> Can_execute_command;
       // bool CanExecuteCache;

        public RelayCommand(Action<object> execute_command, Func<object, bool> Can_execute_command)
        {
            this.execute_command = execute_command;
            this.Can_execute_command = Can_execute_command;
           // CanExecuteCache = CanExecuteCache;
        }

        public bool CanExecute(object parameter)
        {
            if (Can_execute_command != null)
            {
                return true;
            }
            else
            {
                return Can_execute_command(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested += value;
            }
        }

        public void Execute(object parameter)
        {
            this.execute_command(parameter);
        }
    }
}
