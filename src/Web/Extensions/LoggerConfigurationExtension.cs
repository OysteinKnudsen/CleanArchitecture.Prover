using Serilog;
using Serilog.Events;

namespace CleanArchitecture.Prover.Web.Extensions;

internal static class LoggerConfigurationExtension
{
    public static LoggerConfiguration ConfigureLogging(this LoggerConfiguration loggerConfiguration)
    {
        return loggerConfiguration
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()
            .SetLoglevelOverrides()
            .WriteTo.Console();
    }
    
    private static LoggerConfiguration SetLoglevelOverrides(
        this LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
        loggerConfiguration.MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning);
        return loggerConfiguration;
    }
}