namespace PiDriverDaemon.Logging;

public interface ILogOutput : IAsyncDisposable
{
    public Task WriteAsync(byte[] data);
    public Task FlushAsync();
}