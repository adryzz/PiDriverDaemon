using System.Collections.Immutable;

namespace PiDriverDaemon.Logging;

public class ConsoleLogOutput : ILogOutput
{
    protected StreamLogOutput _output;

    public ConsoleLogOutput()
    {
        _output = new StreamLogOutput(Console.OpenStandardOutput());
    }

    public async Task WriteAsync(byte[] data) => await _output.WriteAsync(data);

    public Task FlushAsync() => _output.FlushAsync();
    
    public async ValueTask DisposeAsync() => await _output.DisposeAsync();
}