using InterviewOneExpert.Domain.Models;
using InterviewOneExpert.Infrastructure.Abstraction;
using InterviewOneExpert.Repositories.Abstraction;
using InterviewOneExpert.Services.Abstraction.Validators;
using Moq;

namespace InterviewOneExpert.Services.Tests.Unit;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
    private readonly Mock<ILogger> _loggerMock = new();
    private readonly Mock<IOrderValidator> _orderValidatorMock = new();

    private readonly OrderService _sut;

    public OrderServiceTests()
    {
        _sut = new OrderService(
            _orderRepositoryMock.Object,
            _orderValidatorMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async Task ProcessOrderAsync_ValidOrder_ProcessesSuccessfully()
    {
        // Arrange
        int orderId = 1;

        _orderValidatorMock
            .Setup(v => v.IsValid(orderId))
            .Returns(true);

        _orderRepositoryMock
            .Setup(r => r.GetOrderAsync(orderId))
            .ReturnsAsync("Laptop");

        // Act
        await _sut.ProcessOrderAsync(orderId);

        // Assert
        _orderRepositoryMock.Verify(
            r => r.GetOrderAsync(orderId), 
            Times.Once);
        _loggerMock.Verify(
            l => l.LogInfo(It.IsAny<string>()), 
            Times.AtLeastOnce);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>()), 
            Times.Never);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()), 
            Times.Never);
    }

    [Fact]
    public async Task ProcessOrderAsync_InvalidOrderId_LogsError()
    {
        // Arrange
        int invalidId = -1;

        _orderValidatorMock
            .Setup(v => v.IsValid(invalidId))
            .Returns(false);

        // Act
        await _sut.ProcessOrderAsync(invalidId);

        // Assert
        _orderRepositoryMock.Verify(
            r => r.GetOrderAsync(It.IsAny<int>()), 
            Times.Never);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>()),
            Times.Once);
    }

    [Fact]
    public async Task ProcessOrderAsync_OrderNotFound_LogsError()
    {
        // Arrange
        int orderId = 99;

        _orderValidatorMock
            .Setup(v => v.IsValid(orderId))
            .Returns(true);

        _orderRepositoryMock
            .Setup(r => r.GetOrderAsync(orderId))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        await _sut.ProcessOrderAsync(orderId);

        // Assert
        _orderRepositoryMock.Verify(
            r => r.GetOrderAsync(orderId), 
            Times.Once);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()),
            Times.Once);
    }

    [Fact]
    public void AddOrder_ValidOrder_AddsSuccessfully()
    {
        var order = new Order { Id = 10, Description = "Tablet" };

        _orderValidatorMock
            .Setup(v => v.IsValid(order.Id))
            .Returns(true);

        _sut.AddOrder(order);

        _orderRepositoryMock.Verify(
            r => r.AddOrder(It.Is<Order>(o => o.Id == o.Id && o.Description == order.Description)), 
            Times.Once);
        _loggerMock.Verify(l => l.LogInfo(It.IsAny<string>()), Times.AtLeastOnce);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>()),
            Times.Never);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()),
            Times.Never);
    }

    [Fact]
    public void AddOrder_InvalidOrderId_LogsError()
    {
        var order = new Order { Id = -1, Description = "Invalid" };

        _orderValidatorMock
            .Setup(v => v.IsValid(order.Id))
            .Returns(false);

        _sut.AddOrder(order);

        _orderRepositoryMock.Verify(
            r => r.AddOrder(It.IsAny<Order>()), 
            Times.Never);
        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>()),
            Times.Once);
    }

    [Fact]
    public void AddOrder_RepositoryThrows_LogsError()
    {
        var order = new Order { Id = 5, Description = "Keyboard" };

        _orderValidatorMock
            .Setup(v => v.IsValid(order.Id))
            .Returns(true);

        _orderRepositoryMock
            .Setup(r => r.AddOrder(It.IsAny<Order>()))
            .Throws(new InvalidOperationException("Duplicate"));

        _sut.AddOrder(order);

        _loggerMock.Verify(
            l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()),
            Times.Once);
    }
}
