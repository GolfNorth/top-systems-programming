using System.Text;

namespace Module3.Sample1;

/// <summary>
/// Asynchronous Programming Model (APM) — паттерн Begin/End.
/// Чтение файлов через FileStream.BeginRead/EndRead.
/// SynchronizationContext захватывается при вызове BeginSearch
/// и используется для маршалинга колбэков на UI-поток.
/// </summary>
public static class ApmFileSearcher
{
    public static IAsyncResult BeginSearch(
        string directory, string word,
        Action<string> onStatus, Action<int> onProgress,
        CancellationToken cancellationToken,
        AsyncCallback? callback, object? state)
    {
        var asyncResult = new SearchAsyncResult(callback, state);

        // Захватываем контекст синхронизации вызывающего потока (UI)
        var syncContext = SynchronizationContext.Current;

        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                var files = Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).ToList();
                SearchNextFile(files, 0, directory, word, new List<SearchResult>(),
                    onStatus, onProgress, syncContext, cancellationToken, asyncResult);
            }
            catch (Exception ex)
            {
                asyncResult.Fail(ex);
            }
        });

        return asyncResult;
    }

    public static List<SearchResult> EndSearch(IAsyncResult asyncResult)
    {
        var result = (SearchAsyncResult)asyncResult;
        result.AsyncWaitHandle.WaitOne();

        if (result.Exception != null)
            throw result.Exception;

        return result.Results!;
    }

    private static void SearchNextFile(
        List<string> files, int index, string directory, string word,
        List<SearchResult> results,
        Action<string> onStatus, Action<int> onProgress,
        SynchronizationContext? syncContext,
        CancellationToken cancellationToken,
        SearchAsyncResult asyncResult)
    {
        if (index >= files.Count || cancellationToken.IsCancellationRequested)
        {
            asyncResult.Complete(results);
            return;
        }

        var filePath = files[index];
        var total = files.Count;

        // Маршалим колбэки на UI-поток через захваченный контекст
        var statusText = $"Сканирование: {Path.GetRelativePath(directory, filePath)}";
        var percent = total > 0 ? (index + 1) * 100 / total : 100;

        syncContext?.Post(_ => onStatus(statusText), null);
        Thread.Sleep(500);
        syncContext?.Post(_ => onProgress(percent), null);

        FileStream? stream = null;
        try
        {
            stream = new FileStream(filePath, FileMode.Open, FileAccess.Read,
                FileShare.Read, 4096, FileOptions.Asynchronous);

            if (stream.Length == 0)
            {
                stream.Dispose();
                SearchNextFile(files, index + 1, directory, word, results,
                    onStatus, onProgress, syncContext, cancellationToken, asyncResult);
                return;
            }

            var buffer = new byte[stream.Length];

            // APM для чтения файла
            stream.BeginRead(buffer, 0, buffer.Length, ar =>
            {
                try
                {
                    stream.EndRead(ar);
                    stream.Dispose();

                    var content = Encoding.UTF8.GetString(buffer);
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
                catch
                {
                    stream?.Dispose();
                }

                // Рекурсивный переход к следующему файлу (callback chain)
                SearchNextFile(files, index + 1, directory, word, results,
                    onStatus, onProgress, syncContext, cancellationToken, asyncResult);

            }, null);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            stream?.Dispose();
            SearchNextFile(files, index + 1, directory, word, results,
                onStatus, onProgress, syncContext, cancellationToken, asyncResult);
        }
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
