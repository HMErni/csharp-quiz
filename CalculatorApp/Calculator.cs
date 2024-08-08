namespace CalculatorApp;

public class Calculator
{
    public double PerformOperation(double num1, double num2, string operation)
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

    public double Add(double num1, double num2)
    {
        return num1 + num2;
    }

    public double Subtract(double num1, double num2)
    {
        return num1 - num2;
    }

    public double Multiply(double num1, double num2)
    {
        return num1 * num2;
    }

    public double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return num1 / num2;
    }
}


