using CalculatorApp.Model;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {

            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            var calculator = new Calculator();

            Result<double> getResult = calculator.PerformOperation(num1, num2, operation);

            switch (getResult)
            {
                case Success<double> { value: var result }:
                    Console.WriteLine($"The result is: {result}");
                    break;
                case Failure<double> { exception: InvalidOperationException ex }:
                    Console.WriteLine(ex.Message);
                    break;
                case Failure<double> { exception: DivideByZeroException ex }:
                    Console.WriteLine(ex.Message);
                    break;
                case Failure<double> { exception: Exception ex }:
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric values.");
        }

        Console.WriteLine("Calculation attempt finished.");


    }
}
