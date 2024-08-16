using CalculatorApp.Model;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        var programLogger = LoggerProvider.CreateLogger<Program>();
        var calculatorLogger = LoggerProvider.CreateLogger<Calculator>();
        var inputLogger = LoggerProvider.CreateLogger<InputParser>();

        var inputParser = new InputParser(inputLogger);

        try
        {

            Result<double> input;

            Console.WriteLine("Enter the first number:");
            input = inputParser.ConvertToDouble(Console.ReadLine() ?? string.Empty);

            if (!input.isSuccess)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric values.");
                return;
            }

            double num1 = input is Success<double> { value: var result1 } ? result1 : 0;

            Console.WriteLine("Enter the second number:");
            input = inputParser.ConvertToDouble(Console.ReadLine() ?? string.Empty);

            if (!input.isSuccess)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric values.");
                return;
            }

            double num2 = input is Success<double> { value: var result2 } ? result2 : 0;


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
}
