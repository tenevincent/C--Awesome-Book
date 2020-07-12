using ModuleA.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase, INavigationAware
    {
        IRegionNavigationJournal _journal;

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public DelegateCommand GoBackCommand { get; set; }

        public PersonDetailViewModel()
        {
            GoBackCommand = new DelegateCommand(GoBack);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;

            if (navigationContext.Parameters.ContainsKey("person"))
                SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void GoBack()
        {
            _journal.GoBack();
        }
    }
}
