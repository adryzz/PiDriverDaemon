using Batteryno;
using PiDriverDaemon.Logging;

namespace PiDriverDaemon.Modules;

internal sealed class BatteryManagerModule : BuiltinModule, IObservable<int>
{
    private List<IObserver<int>> observers;

    private int? value;

    public override async Task RunAsync()
    {
        await Program.DaemonInternal.LongTimer.Subscribe(_callback);
    }

    private async Task _callback()
    {
        var b = Power.GetBatteries();
        if (!b.Any())
        {
            value = null;
            await Program.DaemonInternal.Log.LogAsync(new LogMessage("No batteries found.", LogType.Modules, LogLevel.Error));
        }
        else
        {
            value = b.First().Capacity;
        }
        
        foreach (var observer in observers) {
            if (! value.HasValue)
                observer.OnError(new IOException("No batteries found."));
            else
                observer.OnNext(value.Value);
        }
    }

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (! observers.Contains(observer))
            observers.Add(observer);
        return new Unsubscriber<int>(observers, observer);
    }
    
    public override async ValueTask DisposeAsync()
    {
        foreach (var o in observers)
        {
            o.OnCompleted();
        }
    }
}