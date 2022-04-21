using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    internal class Ball : IBall
    {
        private int xPos;
        private int yPos;
        private int radius;

        internal Ball(int x, int y, int radius)
        {
            this.xPos = x;
            this.yPos = y;
            this.radius = radius;
        }
        public int XPos
        {
            get => xPos;
            set
            {
                xPos = value;
                RaisePropertyChanged("XPos");
            }
        }
        public int YPos
        {
            get => yPos;
            set
            {
                yPos = value;
                RaisePropertyChanged("YPos");
            }
        }
        public int Radius
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
