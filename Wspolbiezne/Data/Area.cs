using System;
using System.Collections.Generic;

namespace Data
{
    public class Area
    {
        private readonly int width;
        private readonly int height;
        private readonly List<Ball> balls = new List<Ball>();

        public int Width => width;
        public int Height => height;
        public List<Ball> Balls => balls;
        
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

        private Ball generateBall(int radius) {
            Random rand = new Random();
            bool ok = true;
            int x = radius;
            int y = radius;
            do
            {
                ok = true;
                x = rand.Next(radius, this.width - radius);
                y = rand.Next(radius, this.height - radius);
                foreach (Ball b in this.Balls)
                {
                    double distance = Math.Sqrt(((b.XPos - x) * (b.XPos - x)) + ((b.YPos - y) * (b.YPos - y)));
                    if (distance <= b.Radius + radius)
                    {
                        ok = false;
                        break;
                    };
                }
                if (!ok)
                {
                    continue;
                };
                ok = true;

            } while (!ok);
            double w = 1;
            return new Ball(x, y, w * radius, w);
        }
        public void createBalls(int amount, int radius)
        {
            if (2 * radius > width || 2 * radius > height || radius <= 0 || amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            for (int i = 0; i < amount; i++)
            {
                Ball ball = generateBall(radius);
                this.Balls.Add(ball);
            }
        }
    }
}
