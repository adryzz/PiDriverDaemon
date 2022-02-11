namespace PiDriverDaemon.Logging;

public static class LoggingUtils
{
    public static string GenerateLogName()
    {
        return $"log-{DateTime.Now:yy-MM-dd-HH-m}.log";
    }
}