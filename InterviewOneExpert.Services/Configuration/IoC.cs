using InterviewOneExpert.Services.Abstraction;
using InterviewOneExpert.Services.Abstraction.Validators;
using InterviewOneExpert.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Services.Configuration;

public static class IoC
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
        => services
            .AddTransient<IOrderService, OrderService>()
            .AddTransient<IOrderValidator, OrderValidator>()
            .AddTransient<INotificationService, NotificationService>();
}
