using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Logic.Tests
{
    [TestClass]
    public class LogicAbstractAPITests
    {
        [TestMethod]
        public void createAreaTests()
        {
            LogicAbstractAPI test = LogicAbstractAPI.createApi();
            test.start(600, 400, 100, 2);
            List<LogicBall> ballList = test.getBalls();
            Assert.AreEqual(ballList.Count, 100);
            foreach (LogicBall ball in ballList)
            {
                Assert.AreEqual(ball.Radius, 2);
                Assert.IsTrue((ball.XPos - ball.Radius) >= 0 && (ball.XPos + ball.Radius) <= 600);
                Assert.IsTrue((ball.YPos - ball.Radius) >= 0 && (ball.YPos + ball.Radius) <= 400);
            }
            test.stop();
        }

    }
}