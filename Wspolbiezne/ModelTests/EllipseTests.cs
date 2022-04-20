using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Presentation.Model.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        [TestMethod]
        public void EllipseTest()
        {
            Ball test = new Ball(1, 2, 3);
            Ellipse ellipse = new Ellipse(test);
            Assert.AreEqual(ellipse.Width, 2 * test.Radius);
            Assert.AreEqual(ellipse.Height, 2 * test.Radius);
            Assert.AreEqual(ellipse.X, test.XPos - test.Radius);
            Assert.AreEqual(ellipse.Y, test.YPos - test.Radius);
        }
    }
}