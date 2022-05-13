using System.Threading;
using System.Collections.Generic;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract void createArea(int width, int height, int ballsAmount, int ballRadius);
        public abstract List<Ball> getBalls();

        public abstract void stop();

        public abstract Area Area { get; }
        public static DataAbstractAPI createApi()
        {
            return new DataAPI();
        }        

        internal sealed class DataAPI : DataAbstractAPI
        {
            private readonly object locked = new object();

            private readonly object barrier = new object();

            private int queue_cnt = 0;

            private bool active = false;

            private Area area;

            public bool Active { get => active; set => active = value; }
            public override Area Area { get => area; }        

            public override void createArea(int width, int height, int ballsAmount, int ballRadius)
            {
                this.area = new Area(width, height, ballsAmount, ballRadius);
                this.Active = true;
                List<Ball> balls = getBalls();

                foreach (Ball ball in balls) {
                    Thread t = new Thread(() => {
                        while (this.Active)
                        {
                            lock (locked)
                            {
                                ball.move();   
                            }

                            Thread.Sleep(5);
                        }
                    });
                    t.Start();
                }
            }

            public override List<Ball> getBalls()
            {
                return Area.Balls;
            }

            public override void stop() { 
                this.Active = false;
            }


        }
    }
}
