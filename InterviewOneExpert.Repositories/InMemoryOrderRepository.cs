using InterviewOneExpert.Domain.Models;
using InterviewOneExpert.Repositories.Abstraction;
using System.Collections.Concurrent;

namespace InterviewOneExpert.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<int, Order> _orders = new();

    public InMemoryOrderRepository()
    {
        _orders.TryAdd(1, new Order { Id = 1, Description = "Laptop" });
        _orders.TryAdd(2, new Order { Id = 2, Description = "Phone" });
    }

    public async Task<string> GetOrderAsync(int orderId)
    {
        await Task.Delay(100);

        if (!_orders.TryGetValue(orderId, out var order))
        {
            throw new KeyNotFoundException($"Order with ID {orderId} was not found.");
        }

        return order.Description;
    }

    public void AddOrder(Order? order)
    {
        ArgumentNullException.ThrowIfNull(order);

        if (!_orders.TryAdd(order.Id, order))
            throw new InvalidOperationException($"Order {order.Id} already exists.");
    }
}
