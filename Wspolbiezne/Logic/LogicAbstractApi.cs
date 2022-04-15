using System;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        static LogicAbstractAPI createApi(DataAbstractAPI dataAbstractAPI)
        {
            return new LogicAPI(dataAbstractAPI);
        }

        public abstract void createArea(int width, int height, int ballsAmount, int ballRadius);

        public abstract List<Ball> getBalls();
    }

    internal sealed class LogicAPI : LogicAbstractAPI {

        public LogicAPI(DataAbstractAPI dataAbstractAPI) { 
            this.dataAPI = dataAbstractAPI;
        }

        public override void createArea(int width, int height, int ballsAmount, int ballRadius) {
            this.area = new Area(width, height, ballsAmount, ballRadius);
        }

        public override List<Ball> getBalls() {
            return area.Balls;
        }

        private Area area;

        private DataAbstractAPI dataAPI;
    }
}
