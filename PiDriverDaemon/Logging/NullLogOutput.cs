namespace PiDriverDaemon.Logging;

public sealed class NullLogOutput : ILogOutput
{
    private StreamLogOutput _output;
    
    public NullLogOutput()
    {
        _output = new StreamLogOutput(Stream.Null);
    }

    public async Task WriteAsync(byte[] data) => await _output.WriteAsync(data);

    public async Task FlushAsync() => await _output.FlushAsync();

    public async ValueTask DisposeAsync() => await _output.DisposeAsync();
}