using System;
using System.Collections.Generic;

namespace Logic
{
    internal class Area
    {
        private readonly int width;
        private readonly int height;
        private readonly List<IBall> balls = new List<IBall>();
        private bool active = true;

        internal Area(int width, int height, int ballsAmount, int ballRadius)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.width = width;
            this.height = height;

            createBalls(ballsAmount, ballRadius);
        }

        internal int Width => width;

        internal int Height => height;

        internal List<IBall> Balls => balls;

        internal bool Active { get => active; set => active = value; }
        public void createBalls(int amount, int radius)
        {
            if (2 * radius > width || 2 * radius > height || radius <= 0 || amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                int x = rand.Next(radius, this.width - radius);
                int y = rand.Next(radius, this.height - radius);
                this.Balls.Add(new Ball(x, y, radius));
            }
        }

    }
}
