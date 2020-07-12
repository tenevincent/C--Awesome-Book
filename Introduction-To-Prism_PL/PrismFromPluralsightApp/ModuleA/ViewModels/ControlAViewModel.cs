using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleA.ViewModels
{
    public class ControlAViewModel : BindableBase
    {
        private string _message = "Hello from ControlAViewModel";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ControlAViewModel()
        {

        }
    }
}
