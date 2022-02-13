using PiDriverDaemon.Logging;

namespace PiDriverDaemon;

public static class Program
{
    internal static IDaemon DaemonInternal;
    public static async Task Main(string[] args)
    {
        DaemonInternal = new DaemonBuilder()
            .UseLogger(new LoggerBuilder()
                .AddOutput(new ConsoleLogOutput())
                .AddOutput(new ThrottledFileOutput(LoggingUtils.GenerateLogName()))
                .Build())
            .UseModules("modules")
            .Build();
        
        

        await Task.Delay(-1);
    }
}

