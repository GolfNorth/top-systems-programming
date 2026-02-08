namespace Module3.Sample1;

public class SearchCompletedEventArgs : EventArgs
{
    public List<SearchResult>? Results { get; }
    public Exception? Error { get; }
    public bool Cancelled { get; }

    public SearchCompletedEventArgs(List<SearchResult>? results, Exception? error, bool cancelled)
    {
        Results = results;
        Error = error;
        Cancelled = cancelled;
    }
}

public class StatusChangedEventArgs : EventArgs
{
    public string Status { get; }

    public StatusChangedEventArgs(string status) => Status = status;
}

public class SearchProgressChangedEventArgs : EventArgs
{
    public int ProgressPercentage { get; }

    public SearchProgressChangedEventArgs(int percent) => ProgressPercentage = percent;
}
