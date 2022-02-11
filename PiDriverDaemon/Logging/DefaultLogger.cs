using System.Collections.Immutable;

namespace PiDriverDaemon.Logging;

public class DefaultLogger : ILogger
{
    public ImmutableArray<ILogOutput> Outputs { get; init; }
    
    internal DefaultLogger()
    {
        
    }

    public async ValueTask DisposeAsync()
    {
        foreach (ILogOutput o in Outputs)
        {
            await o.DisposeAsync();
        }
    }
}