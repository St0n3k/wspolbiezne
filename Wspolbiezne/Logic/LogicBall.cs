using Data;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class LogicBall : INotifyPropertyChanged
    {
        private Ball ball;

        public LogicBall(Ball b) { 
            this.ball = b;
            b.PropertyChanged += update;
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "XPos")
            {
                RaisePropertyChanged("XPos");
            }
            else if (e.PropertyName == "YPos")
            {
                RaisePropertyChanged("YPos");
            }
            else if (e.PropertyName == "Radius")
            {
                RaisePropertyChanged("Radius");
            }

        }
        public double XPos {
            get => ball.XPos;
            set
            {
                ball.XPos = value;
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos {
            get => ball.YPos;
            set
            {
                ball.YPos = value;
                RaisePropertyChanged("YPos");
            }
        }
        public double Radius {
            get => ball.Radius;
            set
            {
                if (value > 0)
                {
                    ball.Radius = value;
                    RaisePropertyChanged("Radius");
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
