namespace PiDriverDaemon.Logging;

public static class LoggingUtils
{
    public static string GenerateLogName()
    {
        return $"log-{DateTime.Now:yy-MM-dd-HH-m}.log";
    }
    
    private static readonly Dictionary<LogLevel, string> SeverityColors = new Dictionary<LogLevel, string>()
    {
        {LogLevel.Trace, "\u001b[0m"},//grey
        {LogLevel.Debug, "\u001b[37m"},//white
        {LogLevel.Info, "\u001b[36m"},//cyan
        {LogLevel.Warning, "\u001b[33m"},//yellow
        {LogLevel.Error, "\u001b[31m"},//red
        {LogLevel.Fatal, "\u001b[35m"}//magenta
    };
        
    public static string GetColor(this LogLevel level)
    {
        SeverityColors.TryGetValue(level, out string? code);
        return code ?? string.Empty;
    }
        
    private static readonly Dictionary<LogType, string> TypeColors = new Dictionary<LogType, string>()
    {
        {LogType.Runtime, "\u001b[37m"},//white
        {LogType.Modules, "\u001b[36m"},//cyan
        //{LogType.Api, "\u001b[33m"},//yellow
        //{LogType.Network, "\u001b[35m"},//red
    };
        
    public static string GetColor(this LogType type)
    {
        TypeColors.TryGetValue(type, out string? code);
        return code ?? String.Empty;
    }
}