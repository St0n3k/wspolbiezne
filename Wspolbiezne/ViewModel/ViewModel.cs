using Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class ViewModelController : ViewModelBase
    {
        public ViewModelController()
        {
            StartCommand = new RelayCommand(start);
            StopCommand = new RelayCommand(stop);
            modelApi = ModelAbstractAPI.createApi();
        }

        private ModelAbstractAPI modelApi;

        private int ballNumber = 0;

        public int BallNumber { get => ballNumber; set => ballNumber=value; }

        public ICommand StartCommand { get; set; }

        public ICommand StopCommand { get; set; }

        private ObservableCollection<Ellipse> ballsList;
        public ObservableCollection<Ellipse> BallsList
        {
            get => ballsList;

            set
            {
                if (value.Equals(ballsList))
                    return;
                ballsList = value;
                RaisePropertyChanged("BallsList");
            }
        }

        private bool startEnabled = true;
        public bool StartEnabled
        {
            get => startEnabled;
            set
            {
                startEnabled=value;
                RaisePropertyChanged("StartEnabled");
                RaisePropertyChanged("StopEnabled");
            }
        }
        public bool StopEnabled { get => !startEnabled; }

        private void start()
        {
            modelApi.createArea(ballNumber);
            StartEnabled = false;
            BallsList = modelApi.getBalls();
        }

        private void stop()
        {
            modelApi.stop();
            StartEnabled = true;
        }

    }
}