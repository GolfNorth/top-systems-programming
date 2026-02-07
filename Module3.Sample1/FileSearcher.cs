namespace Module3.Sample1;

public static class FileSearcher
{
    public static async Task<List<SearchResult>> SearchAsync(
        string directory,
        string word,
        IProgress<string> progress,
        IProgress<int> percentProgress,
        CancellationToken cancellationToken)
    {
        var results = new List<SearchResult>();

        var files = Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).ToList();
        int total = files.Count;
        int processed = 0;

        foreach (var filePath in files)
        {
            cancellationToken.ThrowIfCancellationRequested();

            progress.Report($"Сканирование: {Path.GetRelativePath(directory, filePath)}");
            await Task.Delay(500, cancellationToken);
            processed++;
            percentProgress.Report(total > 0 ? processed * 100 / total : 100);

            try
            {
                var content = await File.ReadAllTextAsync(filePath, cancellationToken);
                int count = CountOccurrences(content, word);

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
                // Пропускаем файлы без доступа
            }
        }

        return results;
    }

    private static int CountOccurrences(string text, string word)
    {
        int count = 0;
        int index = 0;

        while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count;
    }
}
