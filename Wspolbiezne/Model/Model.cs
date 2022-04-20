using Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI createApi(LogicAbstractAPI logicAbstractAPI = null)
        {
            return new ModelAPI();
        }

        public abstract void createArea(int number);

        public abstract ObservableCollection<Ellipse> getEllipses();

        public abstract void stop();

        public sealed class ModelAPI : ModelAbstractAPI
        {
            public ModelAPI(LogicAbstractAPI logicAbstractAPI = null) {
                if (logicAbstractAPI == null)
                {
                    this.logicApi = LogicAbstractAPI.createApi();
                }
                else {
                    this.logicApi = logicAbstractAPI;
                }
            }

            private LogicAbstractAPI logicApi = LogicAbstractAPI.createApi(null);

            private ObservableCollection<Ellipse> ellipses = new ObservableCollection<Ellipse>();

            public ObservableCollection<Ellipse> Ellipses { get => ellipses; set => ellipses=value; }

            public override void createArea(int number)
            {
                logicApi.createArea(700, 400, number, 10);
            }

            public override ObservableCollection<Ellipse> getEllipses()
            {
                List<Ball> balls = logicApi.getBalls();
                Ellipses.Clear();
                foreach (Ball b in balls)
                {
                    Ellipses.Add(new Ellipse(b));
                }
                return Ellipses;
            }

            public override void stop()
            {
                logicApi.stop();
            }
        }
    }

    

}
