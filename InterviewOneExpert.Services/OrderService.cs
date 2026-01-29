using InterviewOneExpert.Domain.Models;
using InterviewOneExpert.Infrastructure.Abstractions;
using InterviewOneExpert.Repositories.Abstractions;
using InterviewOneExpert.Services.Abstractions;
using InterviewOneExpert.Services.Abstractions.Validators;

namespace InterviewOneExpert.Services;

public class OrderService(
    IOrderRepository repository, 
    IOrderValidator orderValidator,
    INotificationService notificationService,
    ILogger logger) : IOrderService
{
    public void AddOrder(Order? order)
    {
        try
        {
            logger.LogInfo($"Attempt to add Order {order?.Id}");

            if (!IsNewOrderValid(order))
            {
                logger.LogError($"New Order (ID {order?.Id}) is invalid!");
                return;
            }

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

            if (!orderValidator.IsValid(orderId))
            {
                logger.LogError($"Order ID: {orderId} is invalid!");
                return;
            }

            var order = await repository.GetOrderAsync(orderId);
            notificationService.Send($"Order {orderId} Processed! Description {order}");

            logger.LogInfo($"Successfully processed order {orderId}: {order}");
        }
        catch (Exception ex)
        {
            logger.LogError($"Failed to process order ID {orderId}", ex);
        }
    }

    private bool IsNewOrderValid(Order? order)
        => order is not null && orderValidator.IsValid(order.Id);
}
