using Microsoft.Extensions.Logging;

namespace CalculatorApp;

public class LoggerProvider
{
    private static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
    {
        builder.AddFilter("Microsoft", LogLevel.Warning)
               .AddFilter("System", LogLevel.Warning)
               .AddFilter("CalculatorApp.Program", LogLevel.Debug)
               .AddConsole();
    });

    public static ILogger<T> CreateLogger<T>()
    {
        return LoggerFactory.CreateLogger<T>();
    }
}