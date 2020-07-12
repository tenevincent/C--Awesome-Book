using ModuleA.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace ModuleA.ViewModels
{
    public class PersonListViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<Person> _people;
        private readonly IRegionManager _regionManger;
        IRegionNavigationJournal _journal;

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand<Person> PersonSelectedCommand { get; private set; }

        public PersonListViewModel(IRegionManager regionManger)
        {
            GoForwardCommand = new DelegateCommand(GoForward, CanGoForward);
            PersonSelectedCommand = new DelegateCommand<Person>(PersonSelected);
            CreatePeople();
            _regionManger = regionManger;
        }

        private void PersonSelected(Person person)
        {
            if (person == null)
                return;

            var p = new NavigationParameters();
            p.Add("person", person);

            _regionManger.RequestNavigate("ContentRegion", "PersonDetail", p);
        }

        //demo code only, use a service in production code
        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person()
                {
                    FirstName = String.Format("First {0}", i),
                    LastName = String.Format("Last {0}", i),
                    Age = i
                });
            }

            People = people;
        }

        private void GoForward()
        {
            _journal.GoForward();
        }

        private bool CanGoForward()
        {
            return _journal != null && _journal.CanGoForward;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
