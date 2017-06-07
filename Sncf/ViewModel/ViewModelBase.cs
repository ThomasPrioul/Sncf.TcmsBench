using Sncf.Logging;

namespace Sncf.ViewModel
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        protected readonly ILog log;

        public ViewModelBase(ILog log)
        {
            this.log = log;
        }
    }
}
