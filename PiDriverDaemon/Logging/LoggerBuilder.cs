using System.Collections.Immutable;

namespace PiDriverDaemon.Logging;

public class LoggerBuilder
{
    private List<ILogOutput> _outputs;
    public LoggerBuilder()
    {
        _outputs = new List<ILogOutput>();
    }

    public LoggerBuilder AddOutput(ILogOutput o)
    {
        _outputs.Add(o);
        return this;
    }

    public ILogger Build()
    {
        if (_outputs.Count == 0)
        {
            _outputs.Add(new NullLogOutput());
        }

        return new DefaultLogger()
        {
            Outputs = _outputs.ToImmutableArray()
        };
    }
}