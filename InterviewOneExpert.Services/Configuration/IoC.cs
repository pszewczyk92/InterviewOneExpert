using InterviewOneExpert.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Services.Configuration;

public static class IoC
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
        => services.AddScoped<IOrderService, OrderService>();
}
