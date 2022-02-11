namespace PiDriverDaemon.Logging;

public sealed class ThrottledFileOutput : ILogOutput
{
    private StreamLogOutput _output;
    
    public ThrottledFileOutput(string path, int bufferSize = 2048)
    {
        _output = new StreamLogOutput(new BufferedStream(File.OpenWrite(path), bufferSize));
    }

    public async Task WriteAsync(byte[] data) => await _output.WriteAsync(data);

    public Task FlushAsync() => _output.FlushAsync();

    public async ValueTask DisposeAsync() => await _output.DisposeAsync();
}