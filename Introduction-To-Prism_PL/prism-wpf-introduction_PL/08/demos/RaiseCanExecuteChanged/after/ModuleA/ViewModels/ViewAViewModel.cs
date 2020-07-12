using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _text = "Hello from ViewAViewModel";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set 
            { 
                SetProperty(ref _canExecute, value);

                ClickCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand ClickCommand { get; set; }

        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand(Click, CanClick);
        }

        private bool CanClick()
        {
            return CanExecute;
        }

        private void Click()
        {
            Text = "You Clicked me!";
        }
    }
}
