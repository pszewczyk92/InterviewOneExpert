using InterviewOneExpert.Infrastructure.Abstraction;

namespace InterviewOneExpert.Infrastructure;

public class ConsoleLogger : ILogger
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] INFO  - {message}");
    }

    public void LogError(string message, Exception ex)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] ERROR - {message}");
        Console.WriteLine($"           Exception: {ex.GetType().Name} | {ex.Message}");
        Console.WriteLine($"           StackTrace: {ex.StackTrace}");
    }
}
