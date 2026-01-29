using InterviewOneExpert.Infrastructure.Abstractions;
using InterviewOneExpert.Infrastructure.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Infrastructure.Configuration;

public static class IoC
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddTransient<ILogger, ConsoleLogger>()
            .Configure<LoggingOptions>(configuration.GetSection(LoggingOptions.SectionName));
}
