using CalculatorApp.Model;

namespace CalculatorApp;

public class Calculator
{
    public Result<double> PerformOperation(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "add":
                return Add(num1, num2);
            case "subtract":
                return Subtract(num1, num2);
            case "multiply":
                return Multiply(num1, num2);
            case "divide":
                return Divide(num1, num2);
            default:
                throw new InvalidOperationException("The specified operation is not supported. ");
        }

    }

    public Result<double> Add(double num1, double num2)
    {
        return new Success<double>(num1 + num2);
    }

    public Result<double> Subtract(double num1, double num2)
    {
        return new Success<double>(num1 - num2);
    }

    public Result<double> Multiply(double num1, double num2)
    {
        return new Success<double>(num1 * num2);
    }

    public Result<double> Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            return new Failure<double>(new DivideByZeroException("Cannot divide by zero"));
        }
        return new Success<double>(num1 / num2);
    }
}


