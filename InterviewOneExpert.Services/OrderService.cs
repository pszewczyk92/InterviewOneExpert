using InterviewOneExpert.Infrastructure.Abstraction;
using InterviewOneExpert.Repositories.Abstraction;
using InterviewOneExpert.Services.Abstraction;

namespace InterviewOneExpert.Services;

public class OrderService(IOrderRepository repository, ILogger logger) : IOrderService
{
    public void ProcessOrder(int orderId)
    {
        try
        {
            logger.LogInfo($"Starting processing for order ID {orderId}");

            var order = repository.GetOrder(orderId);

            logger.LogInfo($"Successfully processed order {orderId}: {order}");
        }
        catch (Exception ex)
        {
            logger.LogError($"Failed to process order ID {orderId}", ex);
        }
    }
}
