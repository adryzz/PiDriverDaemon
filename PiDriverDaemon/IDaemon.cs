using PiDriverDaemon.Logging;

namespace PiDriverDaemon;

internal interface IDaemon : IAsyncDisposable
{
    public ILogger Log { get; init; }
    
    public string ModulesPath { get; init; }
    internal Task StartRunAsync();
    
    public ITimer LongTimer { get; protected set; }
    
    public ITimer ShortTimer { get; protected set; }
}