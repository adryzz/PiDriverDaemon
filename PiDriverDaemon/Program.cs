using PiDriverDaemon.Logging;

namespace PiDriverDaemon;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await new DaemonBuilder()
            .UseLogger(new LoggerBuilder()
                .AddOutput(new ConsoleLogOutput())
                .AddOutput(new ThrottledFileOutput(LoggingUtils.GenerateLogName()))
                .Build())
            .Build().StartRunAsync();

        await Task.Delay(-1);
    }
}

