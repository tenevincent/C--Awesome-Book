using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

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
            var p = new DialogParameters();
            p.Add("message", "Hello from ViewAViewModel");

            _dialogService.ShowDialog("MessageDialog", p,OnCallBack);
        }

        private void OnCallBack(IDialogResult dialogResult)
        {
             
                if (dialogResult.Result == ButtonResult.OK)
                {
                    MessageReceived = dialogResult.Parameters.GetValue<string>("myParam");
                }
                else
                {
                    MessageReceived = $"was cancel {dialogResult.Result} " + dialogResult.Parameters.GetValue<string>("myParam");
                }
             
        }
    }
}
