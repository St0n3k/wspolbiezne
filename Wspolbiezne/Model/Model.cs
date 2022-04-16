using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Logic;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI createApi() {
            return new ModelAPI();
        }

        public abstract void createArea(int number);

        public abstract ObservableCollection<Ellipse> getBalls();
        
        public abstract void update();
    }

    public sealed class ModelAPI : ModelAbstractAPI{
        private LogicAbstractAPI logicApi = LogicAbstractAPI.createApi(null);
        private ObservableCollection<Ellipse> ellipses = new ObservableCollection<Ellipse>();

        public ObservableCollection<Ellipse> Ellipses { get => ellipses; set => ellipses=value; }

        public override void createArea(int number) {
            logicApi.createArea(700, 400, number, 10);
        }

        public override ObservableCollection<Ellipse> getBalls() {
            List<Ball> balls = logicApi.getBalls();
            Ellipses.Clear();
            foreach (Ball b in balls)
            {
                Ellipses.Add(new Ellipse(b));
            }
            return Ellipses;
        }

        public override void update() {
            List<Ball> balls = logicApi.getBalls();
            foreach (Ball i in balls)
            {
                i.XPos = i.XPos + 10;
                i.YPos = i.XPos + 10;
            }
        }
    }

}
