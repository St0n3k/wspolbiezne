using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Ball
    {
        private int xPos;
        private int yPos;
        private int radius;

        public Ball(int x, int y, int radius) { 
            this.xPos = x;
            this.yPos = y;
            this.radius = radius;
        }
        public int XPos { get => xPos; set => xPos=value; }
        public int YPos { get => yPos; set => yPos=value; }
        public int Radius { 
            get => radius;
            set
            {
                if (radius > 0)
                {
                    radius=value;
                }
                else { 
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
