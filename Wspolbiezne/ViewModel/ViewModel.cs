using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class ViewModelController : ViewModelBase
    {
        public ViewModelController() {
            HelloCommand = new RelayCommand(Hello);
            modelApi = ModelAbstractAPI.createApi();
            modelApi.createArea(1);
            ballsList = modelApi.getBalls();
        }

        private ModelAbstractAPI modelApi;

        private int ballNumber = 3;

        public int BallNumber { get => ballNumber; set => ballNumber=value; }
        public ICommand HelloCommand { get ; set; }

        private ObservableCollection<Ellipse> ballsList;
        public ObservableCollection<Ellipse> BallsList {
            get => ballsList;
            
            set
            {
                if (value.Equals(ballsList))
                    return;
                ballsList = value;
                RaisePropertyChanged("BallsList");
            }
        }

        private void Hello() {
            BallsList = modelApi.getBalls();
            foreach (Ellipse e in BallsList)
            {
                System.Diagnostics.Debug.WriteLine(Convert.ToString(e.X) + " " + Convert.ToString(e.Y) + " " + Convert.ToString(e.Height) + " " + Convert.ToString(e.Width));
            }
            modelApi.update();

        }

    }
}
