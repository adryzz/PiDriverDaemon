using System.Text;

namespace PiDriverDaemon.Logging;

public class StreamLogOutput : ILogOutput
{
    private Stream _stream;
    
    public StreamLogOutput(Stream stream)
    {
        _stream = stream;
    }
    
    public async Task WriteAsync(byte[] data)
    {
        if (_stream.CanWrite)
        {
            await _stream.WriteAsync(data);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _stream.DisposeAsync();
    }
}