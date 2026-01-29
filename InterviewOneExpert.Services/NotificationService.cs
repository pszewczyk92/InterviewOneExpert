using InterviewOneExpert.Services.Abstractions;

namespace InterviewOneExpert.Services;

public class NotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"[NOTIFICATION] - {message}");
    }
}
