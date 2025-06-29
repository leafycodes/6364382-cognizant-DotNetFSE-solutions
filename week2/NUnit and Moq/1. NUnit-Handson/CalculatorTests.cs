using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;
        private double _result;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _result = 0;
        }

        [TearDown]
        public void Cleanup()
        {
            _calculator = null;
        }

        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(-5, 3, -2)]
        [TestCase(0, 0, 0)]
        [TestCase(2.5, 3.5, 6)]
        public void Add_ValidInputs_ReturnsCorrectSum(double a, double b, double expected)
        {
            _result = _calculator.Add(a, b);
            Assert.That(_result, Is.EqualTo(expected));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<System.ArgumentException>(() =>
                _calculator.Divide(5, 0));
        }
    }
}