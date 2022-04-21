using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class AreaTests
    {
        [TestMethod]
        public void AreaTest()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Area(-1, 1, 2, 3));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Area(2, 0, 2, 3));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Area(-1, -1, 2, 3));



            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Area(1, 1, 1, 1));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Area(3, 3, 0, 1));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Area(3, 3, 1, 0));

            Area area = new Area(3, 3, 3, 1);

            Assert.AreNotEqual(area.Balls.Count, 2);
            Assert.AreEqual(area.Balls.Count, 3);
            Assert.AreEqual(area.Width, 3);
            Assert.AreEqual(area.Height, 3);

        }

    }
}

