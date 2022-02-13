namespace PiDriverDaemon;

internal class AsyncTimer : IAsyncDisposable, ITimer
{
    protected Timer TimerInternal;

    private List<Func<Task>> _callbacks = new List<Func<Task>>();

    public TimeSpan Duration { get; }

    internal AsyncTimer(TimeSpan duration)
    {
        TimerInternal = new Timer(_timerCallback, true, duration, duration);
        Duration = duration;
    }

    public async Task Subscribe(Func<Task> callback)
    {
        if (!_callbacks.Contains(callback))
            _callbacks.Add(callback);
    }
    
    public async Task Unsubscribe(Func<Task> callback)
    { 
        _callbacks.Remove(callback);
    }

    private async void _timerCallback(object? state)
    {
        var callbackTasks = new List<Task>(_callbacks.Count);
        foreach(var callback in _callbacks)
        {
            callbackTasks.Add(callback());
        }

        await Task.WhenAll(callbackTasks);
    }

    public async ValueTask DisposeAsync()
    {
        await TimerInternal.DisposeAsync();
    }
}