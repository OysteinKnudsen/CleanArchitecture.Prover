namespace CleanArchitecture.Prover.Web.Logging;

public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Debug,
        Message = "CleanArchitecture.Prover - done setting up app")]
    public static partial void DoneSettingUpApp(ILogger logger);
}