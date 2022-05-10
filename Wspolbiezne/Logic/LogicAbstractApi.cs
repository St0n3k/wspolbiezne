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
                            foreach (LogicBall b2 in this.Balls)
                            {
                                if (b == b2) continue;
                                lock (b2)
                                {
                                    double xCol = b.XPos + b.xSpeed - b2.XPos + b2.xSpeed;
                                    double yCol = b.YPos + b.ySpeed - b2.YPos + b2.ySpeed;
                                    double distance = Math.Sqrt((xCol * xCol) + (yCol * yCol));
                                    if (distance < b2.Radius + b.Radius)
                                    {
                                        //System.Diagnostics.Debug.WriteLine("1 Waga x: " + b.Weight);
                                        //System.Diagnostics.Debug.WriteLine("2 Waga x: " + b2.Weight);
                                        //System.Diagnostics.Debug.WriteLine("1 Przed x: " + b.xSpeed);
                                        //System.Diagnostics.Debug.WriteLine("2 Przed x: " + b2.xSpeed);
                                        double newB = ((b.xSpeed * (b.Weight - b2.Weight) + (2 * b2.Weight * b2.xSpeed)) / (b.Weight + b2.Weight));
                                        b2.xSpeed = ((b2.xSpeed * (b2.Weight - b.Weight) + (2 * b.Weight * b.xSpeed)) / (b.Weight + b2.Weight));
                                        b.xSpeed = newB;
                                        //System.Diagnostics.Debug.WriteLine("1 Po x: " + b.xSpeed);
                                        //System.Diagnostics.Debug.WriteLine("2 Po x: " + b2.xSpeed);
                                        
                                        //System.Diagnostics.Debug.WriteLine("1 Przed y: " + b.ySpeed);
                                        //System.Diagnostics.Debug.WriteLine("2 Przed y: " + b2.ySpeed);
                                        newB = ((b.ySpeed * (b.Weight - b2.Weight)) + (2 * b2.Weight * b2.ySpeed) / (b.Weight + b2.Weight));
                                        b2.ySpeed = ((b2.ySpeed * (b2.Weight - b.Weight)) + (2 * b.Weight * b.ySpeed) / (b.Weight + b2.Weight));
                                        b.ySpeed = newB;
                                        //System.Diagnostics.Debug.WriteLine("1 Po y: " + b.ySpeed);
                                        //System.Diagnostics.Debug.WriteLine("2 Po y: " + b2.ySpeed);
                                    }

                                }
                            }
                            lock (b)
                            {
                                b.XPos += b.xSpeed;
                                b.YPos += b.ySpeed;
                                if (b.XPos + b.Radius >= dataAPI.Area.Width)
                                {
                                    b.xSpeed = -b.xSpeed;
                                    b.XPos = dataAPI.Area.Width - b.Radius;
                                }
                                if (b.XPos - b.Radius <= 0)
                                {
                                    b.xSpeed = -b.xSpeed;
                                    b.XPos = b.Radius;
                                }
                                if (b.YPos + b.Radius >= dataAPI.Area.Height)
                                {
                                    b.ySpeed = -b.ySpeed;
                                    b.YPos = dataAPI.Area.Height - b.Radius;
                                }
                                if (b.YPos - b.Radius <= 0)
                                {
                                    b.ySpeed = -b.ySpeed;
                                    b.YPos = b.Radius;
                                }

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
