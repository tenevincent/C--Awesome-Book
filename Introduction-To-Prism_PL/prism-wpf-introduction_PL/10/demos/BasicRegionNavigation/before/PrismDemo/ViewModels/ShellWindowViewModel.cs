using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace PrismDemo.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }
        public ShellWindowViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(OnNavigate);

    }

        private void OnNavigate(string url)
        {
            _regionManager.RequestNavigate("ContentRegion", url);
        }
    }
}
