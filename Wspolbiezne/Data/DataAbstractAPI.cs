using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        private Area area;

        public Area Area { get => area; set => area = value; }

        abstract public void createArea(int width, int height, int ballsAmount, int ballRadius);
        public abstract List<Ball> getBalls();
        public static DataAbstractAPI createApi()
        {
            return new DataAPI();
        }

        internal sealed class DataAPI : DataAbstractAPI
        {
            public override void createArea(int width, int height, int ballsAmount, int ballRadius)
            {
                this.Area = new Area(width, height, ballsAmount, ballRadius);
            }

            public override List<Ball> getBalls()
            {
                return Area.Balls;
            }
        }
    }
}
