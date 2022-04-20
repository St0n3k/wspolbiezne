using System;
using System.Collections.Generic;

namespace Logic
{
    public class Area
    {
        public readonly int width;
        public readonly int height;
        private readonly List<Ball> balls = new List<Ball>();
        private bool active = true;

        public Area(int width, int height, int ballsAmount, int ballRadius)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.width = width;
            this.height = height;

            createBalls(ballsAmount, ballRadius);
        }

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

        public int Width => width;

        public int Height => height;

        public List<Ball> Balls => balls;

        public bool Active { get => active; set => active=value; }
    }
}
