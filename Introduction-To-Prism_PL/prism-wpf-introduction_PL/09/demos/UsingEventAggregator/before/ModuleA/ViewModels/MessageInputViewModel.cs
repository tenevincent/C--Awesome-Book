using Prism.Commands;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class MessageInputViewModel : BindableBase
    {
        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageInputViewModel()
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            
        }
    }
}
