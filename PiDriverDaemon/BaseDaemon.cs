using PiDriverDaemon.Logging;

namespace PiDriverDaemon;

public class BaseDaemon : IDaemon
{
    public ILogger Log { get; init; }
    
    public string ModulesPath { get; init; }

    internal BaseDaemon()
    {
        
    }

    public async Task StartRunAsync()
    {
        await Log.LogAsync(new LogMessage("Daemon started!"));
        
    }
    
    public async ValueTask DisposeAsync()
    {
        await Log.DisposeAsync();
    }
}