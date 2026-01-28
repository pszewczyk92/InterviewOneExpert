using InterviewOneExpert.Infrastructure.Enums;

namespace InterviewOneExpert.Infrastructure.Configuration.Options;

public class LoggingOptions
{
    public const string SectionName = "Logging";

    public LogLevel MinimumLevel { get; set; } = LogLevel.Information;
}
