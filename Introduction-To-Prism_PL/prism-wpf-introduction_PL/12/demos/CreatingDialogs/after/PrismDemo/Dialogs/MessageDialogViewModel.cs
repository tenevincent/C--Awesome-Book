using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace PrismDemo.Dialogs
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "My Message Dialog";

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand CloseDialogCommand { get; }
        public DelegateCommand CancelDialogCommand { get; }

        public event Action<IDialogResult> RequestClose;

        public MessageDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(CloseDialog);

            CancelDialogCommand = new DelegateCommand(OnCancelDialog);

        }

        private void OnCancelDialog()
        {
            var buttonResult = ButtonResult.Cancel;

            var parameters = new DialogParameters();
            parameters.Add("myParam", $"Dialog Closed, result: {buttonResult}");

            RequestClose?.Invoke(new DialogResult(buttonResult, parameters));
        }

        private void CloseDialog()
        {
            var buttonResult = ButtonResult.OK;

            var parameters = new DialogParameters();
            parameters.Add("myParam", $"Dialog Closed, result: {buttonResult}");

            RequestClose?.Invoke(new DialogResult(buttonResult, parameters));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }
    }
}
