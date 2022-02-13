using System.Collections.Immutable;
using PiDriverDaemon.Logging;
using PiDriverDaemon.Modules;

namespace PiDriverDaemon;

internal class BaseDaemon : IDaemon
{
    private ITimer _longTimer;
    private ITimer _shortTimer;
    public ILogger Log { get; init; }
    
    public string ModulesPath { get; init; }
    
    internal ImmutableList<IModule> LoadedModules { get; }

    internal BaseDaemon()
    {
        Console.CancelKeyPress += consoleOnCancelKeyPress;
        _longTimer = new AsyncTimer(TimeSpan.FromSeconds(30));
        _shortTimer = new AsyncTimer(TimeSpan.FromSeconds(2));
    }

    private async void consoleOnCancelKeyPress(object? sender, ConsoleCancelEventArgs e)
    {
        await DisposeAsync();
    }

    async Task IDaemon.StartRunAsync()
    {
        await Log.LogAsync(new LogMessage("Daemon started!"));
        if (!Utils.IsRoot())
        {
            await Log.LogAsync(new LogMessage("Not running as root! Some features may not be available.", severity: LogLevel.Warning));
        }
        
    }

    ITimer IDaemon.LongTimer
    {
        get => _longTimer;
        set => _longTimer = value;
    }

    ITimer IDaemon.ShortTimer
    {
        get => _shortTimer;
        set => _shortTimer = value;
    }

    public async ValueTask DisposeAsync()
    {
        await Log.DisposeAsync();
    }
}