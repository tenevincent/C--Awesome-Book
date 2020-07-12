using Prism.Events;
using Prism.Mvvm;
using PrismDemo.Core.Events;
using System.Collections.ObjectModel;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages = new ObservableCollection<string>();
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private bool _isSubscribed = true;
        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set
            {
                SetProperty(ref _isSubscribed, value);
            }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(OnMessageReceived);
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
