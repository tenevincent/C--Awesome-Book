using Prism.Events;
using Prism.Mvvm;
using PrismDemo.Core.Events;
using System.Collections.ObjectModel;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        MessageSentEvent _event;

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

                HandleSubscribe(_isSubscribed);
            }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _event = eventAggregator.GetEvent<MessageSentEvent>();

            HandleSubscribe(true);
        }

        SubscriptionToken _token = null;

        void HandleSubscribe(bool isSubscribed)
        {
            if (isSubscribed)
                _token = _event.Subscribe(OnMessageReceived);
            else
                _event.Unsubscribe(_token);
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
