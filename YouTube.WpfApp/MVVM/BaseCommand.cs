using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YouTube.WpfApp.MVVM
{
    public class BaseCommand : ICommand
    {
        private static bool DegaultCanExecute(object param)
        {
            return true;
        }
        private Action<object> execute;
        private Predicate<object> canExecute;

        public BaseCommand(Action<object> execute): this(execute, DegaultCanExecute)
        {        }
        public BaseCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute");
            }
            if (canExecute == null)
            {
                throw new ArgumentException("canExecute");
            }
            this.execute = execute;
            this.canExecute = canExecute;

        }

        private EventHandler CanExecuteChangedEnternal;

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedEnternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedEnternal += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedEnternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }
    }
}
