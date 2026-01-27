namespace InterviewOneExpert.Services.Abstraction;

public interface IOrderService
{
    Task ProcessOrderAsync(int orderId);
}
