using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismDemo.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public ShellWindowViewModel(IRegionManager regionManager)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _regionManager = regionManager;
        }

        private void Navigate(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName, Callback);
        }

        private void Callback(NavigationResult result)
        {
            if (result.Error != null)
            {
                //handle error
            }
        }
    }
}
