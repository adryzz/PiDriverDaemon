namespace PiDriverDaemon;

public interface ITimer
{
    TimeSpan Duration { get; }
    Task Subscribe(Func<Task> callback);
    
    Task Unsubscribe(Func<Task> callback);
}