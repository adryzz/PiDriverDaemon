using System.Collections.Immutable;

namespace PiDriverDaemon.Logging;

public interface ILogger : IAsyncDisposable
{
    public  ImmutableArray<ILogOutput> Outputs { get; init; }
}