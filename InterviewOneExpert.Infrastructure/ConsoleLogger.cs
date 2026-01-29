using InterviewOneExpert.Infrastructure.Abstractions;
using InterviewOneExpert.Infrastructure.Configuration.Options;
using InterviewOneExpert.Infrastructure.Enums;
using Microsoft.Extensions.Options;

namespace InterviewOneExpert.Infrastructure;

public class ConsoleLogger(
    IOptions<LoggingOptions> loggingOptions) : ILogger
{
    private readonly LogLevel _minimumLogLevel = loggingOptions.Value.MinimumLevel;

    public void LogInfo(string message)
    {
        if (_minimumLogLevel > LogLevel.Information)
        {
            return;
        }

        Console.WriteLine($"[{GetLogTimestamp()}] INFO  - {message}");
    }

    public void LogError(string message, Exception ex)
    {
        if (_minimumLogLevel > LogLevel.Error)
        {
            return;
        }

        Console.WriteLine($"[{GetLogTimestamp()}] ERROR - {message} {Environment.NewLine}" +
            $"           Exception: {ex.GetType().Name} | {ex.Message} {Environment.NewLine}" +
            $"           StackTrace: {ex.StackTrace}");
    }

    public void LogError(string message)
    {
        if (_minimumLogLevel > LogLevel.Error)
        {
            return;
        }

        Console.WriteLine($"[{GetLogTimestamp()}] ERROR - {message}");
    }

    private static string GetLogTimestamp() => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}";
}
