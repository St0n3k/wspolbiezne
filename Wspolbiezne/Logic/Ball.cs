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
        internal int XPos
        {
            get => xPos;
            set
            {
                xPos = value;
                RaisePropertyChanged("XPos");
            }
        }
        internal int YPos
        {
            get => yPos;
            set
            {
                yPos = value;
                RaisePropertyChanged("YPos");
            }
        }
        internal int Radius
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

        public int getXPos() { 
            return xPos;
        }

        public int getYPos()
        {
            return yPos;
        }
        public int getRadius()
        {
            return Radius;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
