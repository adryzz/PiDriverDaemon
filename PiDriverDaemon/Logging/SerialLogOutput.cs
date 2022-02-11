using RJCP.IO.Ports;

namespace PiDriverDaemon.Logging;

public class SerialLogOutput : ILogOutput
{
    private SerialPortStream _port;

    private StreamLogOutput _output;
    
    public SerialLogOutput(string port, int rate = 115200)
    {
        _port = new SerialPortStream(port, rate);
        _output = new StreamLogOutput(_port);
    }

    public async ValueTask DisposeAsync()
    {
        await _output.DisposeAsync();
        await _port.DisposeAsync();
    }

    public async Task WriteAsync(byte[] data) => await _output.WriteAsync(data);

    public async Task FlushAsync() => await _output.FlushAsync();
}