namespace System.Windows.Input
{
    public interface ICommand<T>
    {
        bool CanExecute(T parameter = default(T));
        void Execute(T parameter = default(T));
    }
}
