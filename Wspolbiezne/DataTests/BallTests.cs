using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Data.Tests
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void BallTest()
        {
            Ball ball = new Ball(2, 2, 2, 2);
            Assert.AreEqual(ball.Radius, 2);
            Assert.AreEqual(ball.XPos, 2);
            Assert.AreEqual(ball.YPos, 2);
            Assert.AreEqual(ball.Weight, 2);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => ball.Radius = -2);
            ball.Radius = 1;
            ball.XPos = 1;
            ball.YPos = 1;
            Assert.AreEqual(ball.Radius, 1);
            Assert.AreEqual(ball.XPos, 1);
            Assert.AreEqual(ball.YPos, 1);

            Assert.AreNotEqual(ball.xSpeed, 0);
            Assert.AreNotEqual(ball.ySpeed, 0);

            Assert.AreEqual(ball.Weight, 2);

            Assert.AreEqual(Math.Abs(ball.ySpeed), Math.Sqrt(4 - (ball.xSpeed * ball.xSpeed)));
        }

        [TestMethod]
        public void moveTest()
        {
            Ball ball = new Ball(1, 1, 1, 2);
            double xPos = ball.XPos;
            double yPos = ball.YPos;
            ball.move();
            Assert.AreEqual(xPos + ball.xSpeed, ball.XPos);
            Assert.AreEqual(yPos + ball.ySpeed, ball.YPos);
            Assert.AreNotEqual(xPos, ball.XPos);
            Assert.AreNotEqual(yPos, ball.YPos);


        }
    }
}