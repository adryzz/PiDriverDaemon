namespace PiDriverDaemon.Modules;

internal abstract class BuiltinModule : IModule
{
    public string Name => GetType()?.FullName.Replace("Module", "") ?? "No name";

    public abstract Task RunAsync();

    public abstract ValueTask DisposeAsync();
}