using InterviewOneExpert.Console.Configuration;
using InterviewOneExpert.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = IoC.BuildSerivceProvider();

        var orderService = serviceProvider.GetRequiredService<IOrderService>();

        Console.WriteLine("Order Processing System");

        Task[] tasks =
        [
            orderService.ProcessOrderAsync(1),
            orderService.ProcessOrderAsync(2),
            orderService.ProcessOrderAsync(-1)
        ];
        
        await Task.WhenAll(tasks);

        Console.WriteLine("Processing complete.");
    }
}
