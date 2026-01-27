using InterviewOneExpert.Infrastructure.Configuration;
using InterviewOneExpert.Repositories.Configuration;
using InterviewOneExpert.Services.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Console.Configuration;

internal static class IoC
{
    internal static IServiceProvider BuildSerivceProvider()
    {
        var services = new ServiceCollection();

        return services
            .AddInfrastructure()
            .AddRepositories()
            .AddServices()
            .BuildServiceProvider();
    }
}
