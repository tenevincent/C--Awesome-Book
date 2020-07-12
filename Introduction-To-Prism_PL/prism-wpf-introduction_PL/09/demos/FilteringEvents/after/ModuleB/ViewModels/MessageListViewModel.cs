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

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(OnMessageReceived, 
                ThreadOption.PublisherThread, false,
                message => message.Contains("Brian"));
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
