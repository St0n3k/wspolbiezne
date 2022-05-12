using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        private double xPos;
        private double yPos;
        private double radius;
        private double weight;
        private double[] speed = new double[2];

        public Ball(double x, double y, double radius, double weight)
        {
            this.xPos = x;
            this.yPos = y;
            this.radius = radius;
            this.weight = weight;
            
            Random rand = new Random();
            double xSpeed = 0;
            do
            {
                xSpeed = rand.NextDouble() * (1.9999 + 1.9999) - 1.9999;
            } while (xSpeed == 0);
            
            double ySpeed = Math.Sqrt(4 - (xSpeed * xSpeed));
            ySpeed = (rand.Next(-1, 1) < 0) ? ySpeed : -ySpeed;

            this.speed[0] = xSpeed;
            this.speed[1] = ySpeed;
        }
        public double XPos
        {
            get => xPos;
            set
            {
                xPos = value;
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos
        {
            get => yPos;
            set
            {
                yPos = value;
                RaisePropertyChanged("YPos");
            }
        }

        public double xSpeed { get => speed[0]; set => speed[0] = value; }

        public double ySpeed { get => speed[1]; set => speed[1] = value; }
        public double Radius
        {
            get => radius;
            set
            {
                if (value > 0)
                {
                    radius = value;
                    RaisePropertyChanged("Radius");
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public double Weight
        {
            get => weight;
        }

        public void move()
        {
            this.XPos += this.xSpeed;
            this.YPos += this.ySpeed;
            RaisePropertyChanged("Position");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
