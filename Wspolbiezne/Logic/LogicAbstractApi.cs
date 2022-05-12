using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI createApi(DataAbstractAPI dataAbstractAPI = null)
        {
            return new LogicAPI(dataAbstractAPI);
        }

        public abstract List<LogicBall> getBalls();
        public abstract void start(int width, int height, int ballsAmount, int ballRadius);
        public abstract void stop();

        internal sealed class LogicAPI : LogicAbstractAPI
        {
            private DataAbstractAPI dataAPI;

            bool active = false;

            private List<LogicBall> balls = new List<LogicBall>();
            
            public bool Active { get => active; set => active = value; }
            public List<LogicBall> Balls { get => balls; set => balls = value; }

            internal LogicAPI(DataAbstractAPI dataAbstractAPI = null)
            {
                if (dataAbstractAPI == null)
                {
                    this.dataAPI = DataAbstractAPI.createApi();
                }
                else
                {
                    this.dataAPI = dataAbstractAPI;
                }
            }

            public override void stop()
            {
                dataAPI.stop();
                this.Balls.Clear();
            }

            public override void start(int width, int height, int ballsAmount, int ballRadius) {
                dataAPI.createArea(width, height, ballsAmount, ballRadius);
                foreach (Ball b in dataAPI.getBalls()) {
                    this.Balls.Add(new LogicBall(b));
                    b.PropertyChanged += update;
                }
            }
            public override List<LogicBall> getBalls()
            {
                return this.Balls;
            }

            private void update(object sender, PropertyChangedEventArgs e)
            {
                Ball ball = (Ball)sender;
                if (e.PropertyName == "Position")
                {
                    collide(ball);
                }

            }

            private void borderCollision(Ball main) {
                if ((main.XPos + main.Radius) >= dataAPI.Area.Width)
                {
                    main.xSpeed = -main.xSpeed;
                    main.XPos = dataAPI.Area.Width - main.Radius;
                }
                if ((main.XPos - main.Radius) <= 0)
                {
                    main.xSpeed = -main.xSpeed;
                    main.XPos = main.Radius;
                }
                if ((main.YPos + main.Radius) >= dataAPI.Area.Height)
                {
                    main.ySpeed = -main.ySpeed;
                    main.YPos = dataAPI.Area.Height - main.Radius;
                }
                if ((main.YPos - main.Radius) <= 0)
                {
                    main.ySpeed = -main.ySpeed;
                    main.YPos = main.Radius;
                }
            }

            private void ballCollision(Ball main) {
                foreach (Ball b in dataAPI.getBalls())
                {
                    if (b == main)
                    {
                        continue;
                    }
                    double xCol = b.XPos - main.XPos;
                    double yCol = b.YPos - main.YPos;
                    double distance = Math.Sqrt((xCol * xCol) + (yCol * yCol));
                    if (distance <= (main.Radius + b.Radius))
                    {
                        double newB = ((b.xSpeed * (b.Weight - main.Weight) + (2 * main.Weight * main.xSpeed)) / (b.Weight + main.Weight));
                        main.xSpeed = ((main.xSpeed * (main.Weight - b.Weight) + (2 * b.Weight * b.xSpeed)) / (b.Weight + main.Weight));
                        b.xSpeed = newB;

                        newB = ((b.ySpeed * (b.Weight - main.Weight)) + (2 * main.Weight * main.ySpeed) / (b.Weight + main.Weight));
                        main.ySpeed = ((main.ySpeed * (main.Weight - b.Weight)) + (2 * b.Weight * b.ySpeed) / (b.Weight + main.Weight));
                        b.ySpeed = newB;
                    }
                }
            }
            private void collide(Ball main) {
                borderCollision(main);
                ballCollision(main);                
            }
        }
    }
}
