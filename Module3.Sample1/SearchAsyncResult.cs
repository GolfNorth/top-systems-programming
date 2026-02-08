namespace Module3.Sample1;

public class SearchAsyncResult : IAsyncResult
{
    private readonly ManualResetEvent _waitHandle = new(false);
    private readonly AsyncCallback? _callback;

    public List<SearchResult>? Results { get; private set; }
    public Exception? Exception { get; private set; }

    public object? AsyncState { get; }
    public WaitHandle AsyncWaitHandle => _waitHandle;
    public bool CompletedSynchronously => false;
    public bool IsCompleted => _waitHandle.WaitOne(0);

    public SearchAsyncResult(AsyncCallback? callback, object? state)
    {
        _callback = callback;
        AsyncState = state;
    }

    public void Complete(List<SearchResult> results)
    {
        Results = results;
        _waitHandle.Set();
        _callback?.Invoke(this);
    }

    public void Fail(Exception ex)
    {
        Exception = ex;
        _waitHandle.Set();
        _callback?.Invoke(this);
    }
}