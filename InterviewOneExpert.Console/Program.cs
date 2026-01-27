using InterviewOneExpert.Console.Configuration;
using InterviewOneExpert.Domain.Models;
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
            orderService.ProcessOrderAsync(-1),

            Task.Run(() => orderService.AddOrder(new Order{Id = 1, Description = "Server"})),
            Task.Run(() => orderService.AddOrder(new Order{Id = -1, Description = "Empty"})),
            Task.Run(() => orderService.AddOrder(new Order{Id = 3, Description = "Tablet"})),
            Task.Run(() => orderService.AddOrder(new Order{Id = 4, Description = "Watch"})),
            Task.Run(() => orderService.AddOrder(new Order{Id = 3, Description = "iPad"})),

            orderService.ProcessOrderAsync(3),
            orderService.ProcessOrderAsync(4)
        ];
        
        await Task.WhenAll(tasks);

        Console.WriteLine("Processing complete.");
    }
}
