using InterviewOneExpert.Domain.Models;

namespace InterviewOneExpert.Services.Abstractions;

public interface IOrderService
{
    Task ProcessOrderAsync(int orderId);
    void AddOrder(Order? order);
}
