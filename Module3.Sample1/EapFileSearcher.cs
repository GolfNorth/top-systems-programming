using System.ComponentModel;

namespace Module3.Sample1;

/// <summary>
/// Event-based Asynchronous Pattern (EAP).
/// Прогресс передаётся через события.
/// AsyncOperation.Post автоматически маршалит
/// вызовы на UI-поток — Invoke не нужен.
/// </summary>
public class EapFileSearcher
{
    public event EventHandler<StatusChangedEventArgs>? StatusChanged;
    public event EventHandler<SearchProgressChangedEventArgs>? ProgressChanged;
    public event EventHandler<SearchCompletedEventArgs>? SearchCompleted;

    public void SearchAsync(string directory, string word, CancellationToken cancellationToken)
    {
        var operation = AsyncOperationManager.CreateOperation(null);

        ThreadPool.QueueUserWorkItem(_ =>
        {
            List<SearchResult>? results = null;
            Exception? error = null;
            var cancelled = false;

            try
            {
                results = Search(directory, word, operation, cancellationToken);
                cancelled = cancellationToken.IsCancellationRequested;
            }
            catch (OperationCanceledException)
            {
                cancelled = true;
            }
            catch (Exception ex)
            {
                error = ex;
            }

            operation.PostOperationCompleted(
                _ => SearchCompleted?.Invoke(this, new SearchCompletedEventArgs(results, error, cancelled)),
                null);
        });
    }

    private List<SearchResult> Search(
        string directory, string word,
        AsyncOperation operation, CancellationToken cancellationToken)
    {
        var results = new List<SearchResult>();

        var files = Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).ToList();
        var total = files.Count;

        for (var i = 0; i < total; i++)
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            var filePath = files[i];
            var relativePath = Path.GetRelativePath(directory, filePath);

            // Post автоматически маршалит на UI-поток
            operation.Post(_ => StatusChanged?.Invoke(this,
                new StatusChangedEventArgs($"Сканирование: {relativePath}")), null);

            Thread.Sleep(500);

            var percent = total > 0 ? (i + 1) * 100 / total : 100;
            operation.Post(_ => ProgressChanged?.Invoke(this,
                new SearchProgressChangedEventArgs(percent)), null);

            try
            {
                var content = File.ReadAllText(filePath);
                var count = CountOccurrences(content, word);

                if (count > 0)
                {
                    results.Add(new SearchResult
                    {
                        FileName = Path.GetFileName(filePath),
                        FilePath = filePath,
                        Count = count
                    });
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
            }
        }

        return results;
    }

    private static int CountOccurrences(string text, string word)
    {
        var count = 0;
        var index = 0;

        while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count;
    }
}
