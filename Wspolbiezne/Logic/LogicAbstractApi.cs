using Data;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI createApi(DataAbstractAPI dataAbstractAPI = null)
        {
            return new LogicAPI(dataAbstractAPI);
        }

        public abstract void createArea(int width, int height, int ballsAmount, int ballRadius);

        public abstract void stop();

        public abstract List<Ball> getBalls();

        internal sealed class LogicAPI : LogicAbstractAPI
        {

            public LogicAPI(DataAbstractAPI dataAbstractAPI = null)
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

            public override void createArea(int width, int height, int ballsAmount, int ballRadius)
            {
                this.area = new Area(width, height, ballsAmount, ballRadius);

                foreach (Ball b in area.Balls)
                {
                    Thread t = new Thread(() =>
                    {
                        while (this.area.Active)
                        {
                            Random random = new Random();
                            int newX = b.XPos + random.Next(-1, 2);
                            while (newX == b.XPos || (newX - b.Radius) < 0 || (newX + b.Radius) > area.Width)
                            {
                                newX = b.XPos + random.Next(-1, 2);
                            }
                            int newY = b.YPos + random.Next(-1, 2);
                            while (newY == b.YPos || (newY - b.Radius) < 0 || (newY + b.Radius) > area.Height)
                            {
                                newY = b.YPos + random.Next(-1, 2);
                            }
                            b.XPos = newX;
                            b.YPos = newY;
                            Thread.Sleep(5);
                        }
                    });
                    t.Start();
                }
            }

            public override List<Ball> getBalls()
            {
                return area.Balls;
            }

            public override void stop()
            {
                this.area.Active = false;
            }

            private Area area;

            private DataAbstractAPI dataAPI;
        }


    }
}
