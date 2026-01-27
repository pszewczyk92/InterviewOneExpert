using InterviewOneExpert.Infrastructure.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Infrastructure.Configuration;

public static class IoC
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
        => services.AddScoped<ILogger, ConsoleLogger>();
}
