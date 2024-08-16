using CalculatorApp.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class InputParserTests
    {
        private InputParser _inputParser;
        private ILogger<InputParser> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = Mock.Of<ILogger<InputParser>>();
            _inputParser = new InputParser(_logger);
        }

        [TestCase("69", 69)]
        public void ConvertToDouble_ValidInput_ShouldReturnSuccess(string input, double expectedResult)
        {
            var unitUnderTest = _inputParser.ConvertToDouble(input);
            unitUnderTest.ShouldBeOfType<Success<double>>();

            var successResult = unitUnderTest as Success<double>;
            successResult?.value.ShouldBe(expectedResult);
        }

        [TestCase("bruhhh")]
        public void ConvertToDouble_InvalidInput_ShouldReturnFailure(string input)
        {
            var unitUnderTest = _inputParser.ConvertToDouble(input);
            unitUnderTest.ShouldBeOfType<Failure<double>>();

            var failureResult = unitUnderTest as Failure<double>;
            failureResult?.exception.ShouldBeOfType<FormatException>();
            failureResult?.exception.Message.ShouldBe("Invalid input. Please enter a valid numeric values.");
        }
    }
}