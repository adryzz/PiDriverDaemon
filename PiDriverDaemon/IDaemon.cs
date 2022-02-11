using PiDriverDaemon.Logging;

namespace PiDriverDaemon;

public interface IDaemon : IAsyncDisposable
{
    public ILogger Log { get; init; }
    
    public string ModulesPath { get; init; }
    public Task StartRunAsync();
}