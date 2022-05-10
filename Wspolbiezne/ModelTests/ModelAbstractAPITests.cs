using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace Presentation.Model.Tests
{
    [TestClass()]
    public class ModelAbstractAPITests
    {

        [TestMethod()]
        public void createAreaTest()
        {
            LogicAbstractAPI testLogic = LogicAbstractAPI.createApi();
            ModelAbstractAPI testModel = ModelAbstractAPI.createApi(testLogic);
            testModel.start(10);
            ObservableCollection<IEllipse> colObs = testModel.getEllipses();
            Assert.AreEqual(10, colObs.Count);
            for (int i = 1; i < colObs.Count; i++)
            {
                Assert.AreEqual(colObs[i - 1].Height, colObs[i].Height);
                Assert.AreEqual(colObs[i - 1].Width, colObs[i].Width);
            }

            testModel.stop();

        }

    }
}