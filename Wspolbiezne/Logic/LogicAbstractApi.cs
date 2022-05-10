using Data;
using System;
using System.Collections.Generic;
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
            bool active = false;

            private List<LogicBall> balls = new List<LogicBall>();

            private DataAbstractAPI dataAPI;
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
                this.Active = false;
                this.Balls.Clear();
            }

            public override void start(int width, int height, int ballsAmount, int ballRadius) {
                dataAPI.createArea(width, height, ballsAmount, ballRadius);
                foreach (Ball b in dataAPI.getBalls()) {
                    this.Balls.Add(new LogicBall(b));
                }
                this.Active = true;
                foreach (LogicBall b in this.Balls)
                {
                    Task t = new Task(() =>
                    {
                        while (this.Active)
                        {
                            b.XPos += b.xSpeed;
                            b.YPos += b.ySpeed;
                            if (b.XPos + b.Radius >= dataAPI.Area.Width || b.XPos - b.Radius <= 0) {
                                b.xSpeed = -b.xSpeed;
                            }
                            if (b.YPos + b.Radius >= dataAPI.Area.Height || b.YPos - b.Radius <= 0)
                            {
                                b.ySpeed = -b.ySpeed;
                            }
                            Thread.Sleep(5);
                        }
                    });
                    t.Start();
                }
            }
            public override List<LogicBall> getBalls()
            {
                return this.Balls;
            }
        }
    }
}
