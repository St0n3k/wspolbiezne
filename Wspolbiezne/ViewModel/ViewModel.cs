using Presentation.Model;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class ViewModelController : ViewModelBase
    {
        public ViewModelController(ModelAbstractAPI modelAPI = null)
        {
            StartCommand = new RelayCommand(start);
            StopCommand = new RelayCommand(stop);
            if (modelAPI == null)
            {
                this.modelApi = ModelAbstractAPI.createApi();
            }
            else
            {
                this.modelApi = modelAPI;
            }
        }
        public ViewModelController() : this(null) { }

        private ModelAbstractAPI modelApi;

        private int ballNumber = 1;
        
        public string BallNumber { 
            get => Convert.ToString(ballNumber);
            set
            {
                Regex regex = new Regex("^([0-9]{1,9})$");
                if (regex.IsMatch(value))
                {
                    ballNumber = Convert.ToInt32(value);
                    RaisePropertyChanged("BallNumber");
                }

            }
        }

        public ICommand StartCommand { get; set; }

        public ICommand StopCommand { get; set; }

        private ObservableCollection<IEllipse> ballsList;
        public ObservableCollection<IEllipse> BallsList
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
                startEnabled = value;
                RaisePropertyChanged("StartEnabled");
                RaisePropertyChanged("StopEnabled");
            }
        }
        public bool StopEnabled { get => !startEnabled; }

        private void start()
        {
            try
            {
                modelApi.start(ballNumber);
            }
            catch (System.ArgumentException)
            {
                return;
            }
            StartEnabled = false;
            BallsList = modelApi.getEllipses();
        }

        private void stop()
        {
            modelApi.stop();
            StartEnabled = true;
        }

    }
}