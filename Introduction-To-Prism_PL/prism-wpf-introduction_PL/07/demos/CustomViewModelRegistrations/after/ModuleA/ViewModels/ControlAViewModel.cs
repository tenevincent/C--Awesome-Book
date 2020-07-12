using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class ControlAViewModel : BindableBase
    {
        private string _text = "Hello from ControlAViewModel";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public ControlAViewModel()
        {

        }
    }
}
