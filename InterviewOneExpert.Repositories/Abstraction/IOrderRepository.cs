using InterviewOneExpert.Domain.Models;

namespace InterviewOneExpert.Repositories.Abstraction;

public interface IOrderRepository
{
    Task<string> GetOrderAsync(int orderId);
    void AddOrder(Order? order);
}
