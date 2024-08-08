using NUnit.Framework;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            var result = _calculator.PerformOperation(1, 2, "add");
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifference()
        {
            var result = _calculator.PerformOperation(5, 3, "subtract");
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Multiply_WhenCalled_ReturnsProduct()
        {
            var result = _calculator.PerformOperation(2, 3, "multiply");
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Divide_WhenCalled_ReturnsQuotient()
        {
            var result = _calculator.PerformOperation(6, 2, "divide");
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(6, 0, "divide"));
        }

        [Test]
        public void PerformOperation_InvalidOperation_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(6, 2, "modulus"));
        }
    }
}