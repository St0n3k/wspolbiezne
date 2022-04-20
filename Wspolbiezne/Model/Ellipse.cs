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
        public Ellipse(Ball b)
        {
            this.width = 2 * b.Radius;
            this.height = 2 * b.Radius;
            this.x = b.XPos - b.Radius;
            this.y = b.YPos - b.Radius;
            b.PropertyChanged += update;
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {
            Ball ball = (Ball)sender;
            if (e.PropertyName == "XPos")
            {
                this.X = ball.XPos - ball.Radius;
            }
            else if (e.PropertyName == "YPos")
            {
                this.Y = ball.YPos - ball.Radius;
            }
            else if (e.PropertyName == "Radius")
            {
                this.Width = 2 * ball.Radius;
                this.Height = 2 * ball.Radius;
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
                width=value;
                RaisePropertyChanged("Width");
            }
        }
        public int Height
        {
            get => height;
            set
            {
                height=value;
                RaisePropertyChanged("Height");
            }
        }
        public int X
        {
            get => x;
            set
            {
                x=value;
                RaisePropertyChanged("X");
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y=value;
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

