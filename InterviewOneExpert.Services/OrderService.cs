using InterviewOneExpert.Domain.Models;
using InterviewOneExpert.Infrastructure.Abstraction;
using InterviewOneExpert.Repositories.Abstraction;
using InterviewOneExpert.Services.Abstraction;

namespace InterviewOneExpert.Services;

public class OrderService(IOrderRepository repository, ILogger logger) : IOrderService
{
    public void AddOrder(Order? order)
    {
        try
        {
            logger.LogInfo($"Attempt to add Order {order?.Id}");

            repository.AddOrder(order);

            logger.LogInfo($"Successfully added order {order?.Id}: {order?.Description}");
        }
        catch (Exception ex)
        {
            logger.LogError($"Failed to add Order {order?.Id}", ex);
        }
    }

    public async Task ProcessOrderAsync(int orderId)
    {
        try
        {
            logger.LogInfo($"Starting processing for order ID {orderId}");

            var order = await repository.GetOrderAsync(orderId);

            logger.LogInfo($"Successfully processed order {orderId}: {order}");
        }
        catch (Exception ex)
        {
            logger.LogError($"Failed to process order ID {orderId}", ex);
        }
    }
}
