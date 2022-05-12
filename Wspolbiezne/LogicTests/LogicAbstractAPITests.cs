using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace Logic.Tests
{
    [TestClass]
    public class LogicAbstractAPITests
    {
        [TestMethod]
        public void createAreaTests()
        {
            LogicAbstractAPI test = LogicAbstractAPI.createApi();
            test.start(600, 400, 50, 2);
            List<LogicBall> ballList = test.getBalls();
            Assert.AreEqual(ballList.Count, 50);
            foreach (LogicBall ball in ballList)
            {
                Assert.AreEqual(ball.Radius, 2);
                Assert.IsTrue((ball.XPos - ball.Radius) >= 0 - 2 && (ball.XPos + ball.Radius) <= 600 + 2);
                Assert.IsTrue((ball.YPos - ball.Radius) >= 0 - 2 && (ball.YPos + ball.Radius) <= 400 + 2);
            }
            test.stop();
        }

    }
}