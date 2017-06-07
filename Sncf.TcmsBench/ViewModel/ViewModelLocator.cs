using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Sncf.Logging;

namespace Sncf.TcmsBench.ViewModel
{
    public class ViewModelLocator
    {
        public static ISimpleIoc Ioc { get; } = SimpleIoc.Default;

        static ViewModelLocator instance;
        public static ViewModelLocator Instance => instance ?? (instance = new ViewModelLocator());

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => Ioc);
            Ioc.Register<ILogFactory, LogFactory>();
            Ioc.Register<MainViewModel>();
        }

        ViewModelLocator() { }

        public MainViewModel Main => Ioc.GetInstance<MainViewModel>();
    }
}
