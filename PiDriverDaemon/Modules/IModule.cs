namespace PiDriverDaemon.Modules;

public interface IModule : IAsyncDisposable
{
    public string Name { get; }
    public Task RunAsync();
}