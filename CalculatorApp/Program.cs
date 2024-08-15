using CalculatorApp.Model;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        var programLogger = LoggerProvider.CreateLogger<Program>();
        var calculatorLogger = LoggerProvider.CreateLogger<Calculator>();
        try
        {
            Console.WriteLine("Enter the first number:");
            double num1 = convertToDouble(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Enter the second number:");
            double num2 = convertToDouble(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            var calculator = new Calculator(calculatorLogger);

            Result<double> getResult = calculator.PerformOperation(num1, num2, operation);

            switch (getResult)
            {
                case Success<double> { value: var result }:
                    programLogger.LogInformation($"The result is: {result}", result);
                    break;
                case Failure<double> { exception: InvalidOperationException ex }:
                    programLogger.LogError(ex, "An error occured: {}", ex.Message);
                    break;
                case Failure<double> { exception: DivideByZeroException ex }:
                    programLogger.LogError(ex, "An error occured: {}", ex.Message);
                    break;
                case Failure<double> { exception: Exception ex }:
                    programLogger.LogError(ex, "An error occured: {}", ex.Message);
                    break;
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            programLogger.LogError(ex, "An error occured: {}", ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            programLogger.LogError(ex, "An error occured: {}", ex.Message);
        }
        finally
        {
            Console.WriteLine("Calculation attempt finished.");
        }

    }

    static double convertToDouble(string input)
    {
        double result;

        try
        {
            result = Convert.ToDouble(input);
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid input. Please enter a valid numeric values.");
        }

        return result;
    }
}
