using CalculatorApp.Model;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

public class InputParser
{
    private readonly ILogger _logger;

    public InputParser(ILogger logger)
    {
        _logger = logger;
    }

    public Result<double> ConvertToDouble(string input)
    {
        bool isValid = double.TryParse(input, out double result);

        if (!isValid)
        {
            _logger.LogError("Invalid input. Please enter a valid numeric values.");
            return new Failure<double>(new FormatException("Invalid input. Please enter a valid numeric values."));
        }

        return new Success<double>(result);
    }
}