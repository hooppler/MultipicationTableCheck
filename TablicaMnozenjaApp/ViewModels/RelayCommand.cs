using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TablicaMnozenjaApp.ViewModels
{
    class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }


        public void Execute(object param)
        {
            execute(param);
        }

        public bool CanExecute(object param)
        {
            if (canExecute == null)
                return true;
            return canExecute(param);
        }

        public event EventHandler CanExecuteChanged;

        public void ExecuteCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
