using System;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelController
    {
        public ViewModelController() {
            HelloCommand = new RelayCommand(Hello);
        }
        private int ballNumber = 1;

        public int BallNumber { get => ballNumber; set => ballNumber=value; }
        public ICommand HelloCommand { get ; set; }

        private ICommand helloCommand;

        private void Hello() {
            System.Diagnostics.Debug.WriteLine("test");
        }
    }
}
