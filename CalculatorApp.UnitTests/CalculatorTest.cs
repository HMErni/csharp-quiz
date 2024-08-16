using CalculatorApp.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;
        private ILogger<Calculator> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = Mock.Of<ILogger<Calculator>>();
            _calculator = new Calculator(_logger);
        }

        [TestCase(65, 4, 69)]
        public void Add_TwoNumbers_ShouldReturnSum(double num1, double num2, double expectedResult)
        {
            var unitUnderTest = _calculator.Add(num1, num2);
            unitUnderTest.ShouldBeOfType<Success<double>>();

            var successResult = unitUnderTest as Success<double>;
            successResult?.value.ShouldBe(expectedResult);

        }

        [TestCase(100, 31, 69)]
        public void Subtract_TwoNumbers_ShouldReturnDifference(double num1, double num2, double expectedResult)
        {
            var unitUnderTest = _calculator.Subtract(num1, num2);
            unitUnderTest.ShouldBeOfType<Success<double>>();

            var successResult = unitUnderTest as Success<double>;
            successResult?.value.ShouldBe(expectedResult);
        }

        [TestCase(23, 3, 69)]
        public void Multiply_TwoNumbers_ShouldReturnProduct(double num1, double num2, double expectedResult)
        {
            var unitUnderTest = _calculator.Multiply(num1, num2);
            unitUnderTest.ShouldBeOfType<Success<double>>();

            var successResult = unitUnderTest as Success<double>;
            successResult?.value.ShouldBe(expectedResult);
        }

        [TestCase(15, 3, 5)]
        public void Divide_TwoNumbers_ShouldReturnQuotient(double num1, double num2, double expectedResult)
        {
            var unitUnderTest = _calculator.Divide(num1, num2);
            unitUnderTest.ShouldBeOfType<Success<double>>();

            var successResult = unitUnderTest as Success<double>;
            successResult?.value.ShouldBe(expectedResult);
        }

        [TestCase(69, 0)]
        public void Divide_ByZero_ThrowsDivideByZeroException(double num1, double num2)
        {
            var unitUnderTest = _calculator.Divide(num1, num2);
            unitUnderTest.ShouldBeOfType<Failure<double>>();

            var failureResult = unitUnderTest as Failure<double>;

            failureResult?.exception.ShouldBeOfType<DivideByZeroException>();
            failureResult?.exception.Message.ShouldBe("Cannot divide by zero.");
        }

        [TestCase(69, 2, "modulus")]
        public void PerformOperation_InvalidOperation_ThrowsInvalidOperationException(double num1, double num2, string operation)
        {
            var unitUnderTest = _calculator.PerformOperation(num1, num2, operation);
            unitUnderTest.ShouldBeOfType<Failure<double>>();

            var failureResult = unitUnderTest as Failure<double>;

            failureResult?.exception.ShouldBeOfType<InvalidOperationException>();
            failureResult?.exception.Message.ShouldBe("The specified operation is not supported.");
        }
    }
}