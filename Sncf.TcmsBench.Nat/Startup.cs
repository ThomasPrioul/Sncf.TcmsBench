using System;

namespace Sncf.TcmsBench.Nat
{
    class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            //var config = ViewModel.ViewModelLocator.Ioc;

            var app = new App();
            return app.Run(new View.MainWindow());
        }
    }
}
