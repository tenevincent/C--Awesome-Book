using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;

        private string _messageReceived;
        public string MessageReceived
        {
            get { return _messageReceived; }
            set { SetProperty(ref _messageReceived, value); }
        }

        public DelegateCommand ShowDialogCommand { get; }

        public ViewAViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        private void ShowDialog()
        {
            _dialogService.ShowMessageDialog("Hello from ViewAViewModel", r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    MessageReceived = r.Parameters.GetValue<string>("myParam");
                }
                else
                {
                    MessageReceived = "Not closed by user";
                }
            });
        }
    }
}
