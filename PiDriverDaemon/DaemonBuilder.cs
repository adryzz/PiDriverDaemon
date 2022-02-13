using PiDriverDaemon.Logging;

namespace PiDriverDaemon;

internal class DaemonBuilder
{
    private ILogger _logger;
    private string _modulesPath;
    
    internal DaemonBuilder()
    {
        
    }

    internal IDaemon Build()
    {
        return new BaseDaemon()
        {
            Log = _logger,
            ModulesPath = _modulesPath
        };
    }

    public DaemonBuilder UseLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }

    public DaemonBuilder UseModules(string modulesPath)
    {
        _modulesPath = modulesPath;
        return this;
    }
}