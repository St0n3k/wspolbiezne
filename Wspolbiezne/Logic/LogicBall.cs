using Data;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class LogicBall : INotifyPropertyChanged
    {
        private readonly Ball ball;
        private double weight;
        private int[] speed = new int[2];

        public LogicBall(Ball b) { 
            this.ball = b;
            Random rand = new Random();
            int xSpeed = 0;
            do
            {
                xSpeed = rand.Next(-2, 3);
            } while (xSpeed == 0);
            int ySpeed = 4 - Math.Abs(xSpeed);
            ySpeed = (rand.Next(-1,1) < 0) ? ySpeed : -ySpeed;
            this.speed[0] = xSpeed;
            this.speed[1] = ySpeed;

        }
        public int XPos {
            get => ball.XPos;
            set
            {
                ball.XPos = value;
                RaisePropertyChanged("XPos");
            }
        }
        public int YPos {
            get => ball.YPos;
            set
            {
                ball.YPos = value;
                RaisePropertyChanged("YPos");
            }
        }
        public int Radius {
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
        public double Weight { get => weight; set => weight = value; }
        public int xSpeed { get => speed[0]; set => speed[0] = value; }

        public int ySpeed { get => speed[1]; set => speed[1] = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
