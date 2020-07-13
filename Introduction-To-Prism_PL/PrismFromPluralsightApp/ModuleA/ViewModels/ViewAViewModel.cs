using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            // this.ClickCommand = new DelegateCommand(OnClick,CanClick);

            this.ClickCommand = new DelegateCommand(OnClick).ObservesCanExecute(() => CanExecute);
            // Using ObservesProperty
            //   this.ClickCommand = new DelegateCommand(OnClick,CanClick).ObservesProperty(()  => CanExecute);
        }


        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                SetProperty(ref _canExecute, value);

                // Raise Can Execute
              //  ClickCommand.RaiseCanExecuteChanged();
            }
        }

        //private bool CanClick()
        //{
        //    return CanExecute;
        //}

        private void OnClick()
        {
            Message = "You Clicked me!";
        }

        public DelegateCommand ClickCommand { get; set; }
    }
}
