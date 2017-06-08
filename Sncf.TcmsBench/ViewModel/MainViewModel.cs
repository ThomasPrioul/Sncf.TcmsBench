using GalaSoft.MvvmLight.Command;
using Sncf.ViewModel;
using Sncf.ViewModel.Command;
using System;
using System.Windows.Input;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Sncf.TcmsBench.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        string title = "AppTitle";
        
        #region Properties

        public ICommand TestCommand { get; }

        public ICommand<string> TestTypedCommand { get; }

        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        #endregion

        public MainViewModel(Logging.ILogFactory logFactory) : base(logFactory.GetLogger(typeof(MainViewModel)))
        {
            TestCommand = new RelayCommand(TestExecuted);
            TestTypedCommand = new Command<string>(TestTypedExecuted);
            log.Info("Hello!");
        }

        void TestTypedExecuted(string obj)
        {
            throw new NotImplementedException();
        }

        void TestExecuted()
        {
            throw new NotImplementedException();
        }
    }
}
