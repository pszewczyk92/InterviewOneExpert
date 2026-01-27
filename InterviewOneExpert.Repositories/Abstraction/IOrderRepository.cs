namespace InterviewOneExpert.Repositories.Abstraction;

public interface IOrderRepository
{
    Task<string> GetOrderAsync(int orderId);
}
