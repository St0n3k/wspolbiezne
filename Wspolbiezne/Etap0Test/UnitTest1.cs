using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etap0Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestMultiply()
        {
            Example.Calculator calc = new Example.Calculator();

            Assert.AreEqual(calc.Multiply(2, 3), 6);

            Assert.AreEqual(calc.Multiply(3, 4), calc.Multiply(4, 3));
        }

        [TestMethod]
        public void TestDivide()
        {
            Example.Calculator calc = new Example.Calculator();
            Assert.AreEqual(calc.Divide(4, 2), 2);
            Assert.ThrowsException<System.DivideByZeroException>(() => calc.Divide(4, 0));
        }
    }
}