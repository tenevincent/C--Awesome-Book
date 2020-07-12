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

        public DelegateCommand<string> ClickCommand { get; set; }

        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand<string>(Click, CanClick);
        }

        private bool CanClick(string parameter)
        {
            return true;
        }

        private void Click(string parameter)
        {
            Text = parameter;
        }
    }
}
