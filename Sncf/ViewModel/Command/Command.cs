using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Sncf.ViewModel.Command
{
    public class Command<T> : RelayCommand<T>, ICommand<T>
    {
        public Command(Action<T> execute) : base(execute)
        {
        }

        public Command(Action<T> execute, Func<T, bool> canExecute) : base(execute, canExecute)
        {
        }

        public bool CanExecute(T parameter = default(T))
        {
            return base.CanExecute(parameter);
        }

        public void Execute(T parameter = default(T))
        {
            base.Execute(parameter);
        }
    }
}
