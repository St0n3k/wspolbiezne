using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void BallTest()
        {
            Ball ball = new Ball(2, 2, 2);
            Assert.AreEqual(ball.Radius, 2);
            Assert.AreEqual(ball.XPos, 2);
            Assert.AreEqual(ball.YPos, 2);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => ball.Radius = -2);
            ball.Radius = 1;
            ball.XPos = 1;
            ball.YPos = 1;
            Assert.AreEqual(ball.Radius, 1);
            Assert.AreEqual(ball.XPos, 1);
            Assert.AreEqual(ball.YPos, 1);
        }
    }
}