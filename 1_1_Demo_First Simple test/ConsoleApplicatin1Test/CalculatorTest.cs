using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void CalculatorIsICalculator()
        {
            var calculator = new Calculator();
            Assert.IsInstanceOfType(calculator, typeof(ICalculator));
        }

        [TestMethod]
        public void Add_Given1and2_Expect3()
        {
            var calculator = new Calculator();
            var actual = calculator.Add(1, 2);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Add_Given2and2_Expect4()
        {
            var calculator = new Calculator();
            var actual = calculator.Add(2, 2);

            Assert.AreEqual(4, actual);
        }

        [TestMethod]
        public void Add_Given3and2_Expect5()
        {
            var calculator = new Calculator();
            var actual = calculator.Add(3, 2);

            Assert.AreEqual(5, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_GivenIntMaxandIntMax_ThrowsException()
        {
            var calculator = new Calculator();
            var actual = calculator.Add(int.MaxValue, int.MaxValue);
        }


    }
}