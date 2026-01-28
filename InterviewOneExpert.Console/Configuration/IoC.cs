using InterviewOneExpert.Infrastructure.Configuration;
using InterviewOneExpert.Repositories.Configuration;
using InterviewOneExpert.Services.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewOneExpert.Console.Configuration;

internal static class IoC
{
    internal static IServiceProvider BuildSerivceProvider()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        return services
            .AddInfrastructure(configuration)
            .AddRepositories()
            .AddServices()
            .BuildServiceProvider();
    }
}
