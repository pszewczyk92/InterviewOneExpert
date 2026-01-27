using InterviewOneExpert.Console.Configuration;
using InterviewOneExpert.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = IoC.BuildSerivceProvider();

        var orderService = serviceProvider.GetRequiredService<IOrderService>();

        Console.WriteLine("Order Processing System");

        Task[] tasks =
        [
            Task.Run(() => { orderService.ProcessOrder(1); }),
            Task.Run(() => { orderService.ProcessOrder(2); }),
            Task.Run(() => { orderService.ProcessOrder(-1); }),
        ];
        Task.WaitAll(tasks);

        Console.WriteLine("Processing complete.");
    }
}
