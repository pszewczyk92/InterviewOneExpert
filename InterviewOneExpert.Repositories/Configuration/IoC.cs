using InterviewOneExpert.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Repositories.Configuration;

public static class IoC
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        => services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
}
