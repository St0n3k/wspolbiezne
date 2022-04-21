using Logic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.Model
{
    public class Ellipse : INotifyPropertyChanged
    {
        private int width;
        private int height;
        private int x;
        private int y;
        public Ellipse(IBall b)
        {
            this.width = 2 * b.getRadius();
            this.height = 2 * b.getRadius();
            this.x = b.getXPos() - b.getRadius();
            this.y = b.getYPos() - b.getRadius();
            b.PropertyChanged += update;
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {
            IBall ball = (IBall)sender;
            if (e.PropertyName == "XPos")
            {
                this.X = ball.getXPos() - ball.getRadius();
            }
            else if (e.PropertyName == "YPos")
            {
                this.Y = ball.getYPos() - ball.getRadius();
            }
            else if (e.PropertyName == "Radius")
            {
                this.Width = 2 * ball.getRadius();
                this.Height = 2 * ball.getRadius();
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public int Width
        {
            get => width;
            set
            {
                width = value;
                RaisePropertyChanged("Width");
            }
        }
        public int Height
        {
            get => height;
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }
        public int X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged("X");
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
                RaisePropertyChanged("Y");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

