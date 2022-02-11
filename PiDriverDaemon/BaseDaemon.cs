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
        
    }
    
    public async ValueTask DisposeAsync()
    {
        await Log.DisposeAsync();
    }
}