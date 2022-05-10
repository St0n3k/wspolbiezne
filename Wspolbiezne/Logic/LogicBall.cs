using Data;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class LogicBall : INotifyPropertyChanged
    {
        private readonly Ball ball;
        private double[] speed = new double[2];

        public LogicBall(Ball b) { 
            this.ball = b;
            Random rand = new Random();
            double xSpeed = 0;
            do
            {
                xSpeed = rand.Next(-2, 3);
            } while (xSpeed == 0);
            double ySpeed = Math.Sqrt(16 - (xSpeed * xSpeed));
            ySpeed = (rand.Next(-1,1) < 0) ? ySpeed : -ySpeed;
            this.speed[0] = 0.5 * xSpeed;
            this.speed[1] = 0.5 * ySpeed;

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
        public double Weight { get => ball.Weight; set => ball.Weight = value; }
        public double xSpeed { get => speed[0]; set => speed[0] = value; }

        public double ySpeed { get => speed[1]; set => speed[1] = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
