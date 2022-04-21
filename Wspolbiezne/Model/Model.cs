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

        public abstract ObservableCollection<IEllipse> getEllipses();

        public abstract void stop();

        internal sealed class ModelAPI : ModelAbstractAPI
        {
            internal ModelAPI(LogicAbstractAPI logicAbstractAPI = null)
            {
                if (logicAbstractAPI == null)
                {
                    this.logicApi = LogicAbstractAPI.createApi();
                }
                else
                {
                    this.logicApi = logicAbstractAPI;
                }
            }

            private LogicAbstractAPI logicApi = LogicAbstractAPI.createApi(null);

            private ObservableCollection<IEllipse> ellipses = new ObservableCollection<IEllipse>();

            internal ObservableCollection<IEllipse> Ellipses { get => ellipses; set => ellipses = value; }

            public override void createArea(int number)
            {
                logicApi.createArea(700, 400, number, 10);
            }

            public override ObservableCollection<IEllipse> getEllipses()
            {
                List<IBall> balls = logicApi.getBalls();
                Ellipses.Clear();
                foreach (IBall b in balls)
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
