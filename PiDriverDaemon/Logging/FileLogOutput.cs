namespace PiDriverDaemon.Logging;

public class FileLogOutput : ILogOutput
{
    protected StreamLogOutput _output;

    public FileLogOutput(string path)
    {
        _output = new StreamLogOutput(File.OpenWrite(path));
    }
    
    public async Task WriteAsync(byte[] data) => await _output.WriteAsync(data);

    public async Task FlushAsync() => await _output.FlushAsync();

    public async ValueTask DisposeAsync() => await _output.DisposeAsync();
}