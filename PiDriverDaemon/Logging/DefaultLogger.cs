using System.Collections.Immutable;
using System.Text;
using System.Threading.Channels;

namespace PiDriverDaemon.Logging;

public class DefaultLogger : ILogger
{
    public ImmutableArray<ILogOutput> Outputs { get; init; }
    
    private Channel<LogMessage> logChannel = Channel.CreateUnbounded<LogMessage>();
    
    private Timer autoFlush;
    
    internal DefaultLogger(int timeout = 200)
    {
        autoFlush = new Timer(_asyncCallback, true, timeout, timeout);
    }
    
    private async void _asyncCallback(object? o)
    {
        if (logChannel.Reader.Count > 0)
            await FlushAsync();
    }
    
    public async Task LogAsync(LogMessage message)
    {
        await logChannel.Writer.WriteAsync(message);
        //await FlushAsync();
    }

    public async Task FlushAsync()
    {
        await foreach (LogMessage m in ReadAvailableLogsAsync())
        {
            byte[] message = Encoding.ASCII.GetBytes(m.ToString());
            foreach (ILogOutput o in Outputs)
            {
                await o.WriteAsync(message);
            }
        }

        foreach (ILogOutput o in Outputs)
        {
            await o.FlushAsync();
        }
    }
    
    private async IAsyncEnumerable<LogMessage> ReadAvailableLogsAsync()
    {
        while (logChannel.Reader.Count > 0)
        {
            yield return await logChannel.Reader.ReadAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        await autoFlush.DisposeAsync();
        await FlushAsync();
        foreach (ILogOutput o in Outputs)
        {
            await o.DisposeAsync();
        }
    }
}