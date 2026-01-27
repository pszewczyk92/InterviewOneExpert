using InterviewOneExpert.Domain.Models;

namespace InterviewOneExpert.Services.Abstraction;

public interface IOrderService
{
    Task ProcessOrderAsync(int orderId);
    void AddOrder(Order? order);
}
