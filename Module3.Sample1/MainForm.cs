namespace Module3.Sample1;

public partial class MainForm : Form
{
    private CancellationTokenSource? _cts;

    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonBrowse_Click(object? sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Выберите директорию для поиска"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            textBoxDirectory.Text = dialog.SelectedPath;
        }
    }

    private void buttonSearch_Click(object? sender, EventArgs e)
    {
        var directory = textBoxDirectory.Text.Trim();
        var word = textBoxWord.Text.Trim();

        if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
        {
            MessageBox.Show("Укажите существующую директорию.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrEmpty(word))
        {
            MessageBox.Show("Укажите слово для поиска.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        SetSearching(true);
        listViewResults.Items.Clear();
        progressBar.Value = 0;
        _cts = new CancellationTokenSource();

        if (radioApm.Checked)
            StartApmSearch(directory, word);
        else
            StartEapSearch(directory, word);
    }

    #region APM: Begin/End + SynchronizationContext

    private void StartApmSearch(string directory, string word)
    {
        // колбэки прогресса маршалятся внутри ApmFileSearcher
        // через захваченный SynchronizationContext — Invoke не нужен
        ApmFileSearcher.BeginSearch(
            directory, word,
            status => labelStatus.Text = status,
            percent => progressBar.Value = percent,
            _cts!.Token,
            OnApmSearchCompleted, null);
    }

    private void OnApmSearchCompleted(IAsyncResult ar)
    {
        // AsyncCallback вызывается на фоновом потоке —
        // здесь Invoke по-прежнему нужен
        try
        {
            var results = ApmFileSearcher.EndSearch(ar);

            Invoke(() =>
            {
                if (_cts?.IsCancellationRequested == true)
                    labelStatus.Text = "Поиск отменён.";
                else
                    ShowResults(results);

                FinishSearch();
            });
        }
        catch (Exception ex)
        {
            Invoke(() =>
            {
                MessageBox.Show($"Ошибка поиска:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelStatus.Text = "Ошибка.";
                FinishSearch();
            });
        }
    }

    #endregion

    #region EAP: события + AsyncOperation (Invoke не нужен)

    private void StartEapSearch(string directory, string word)
    {
        var searcher = new EapFileSearcher();

        // события автоматически маршалятся на UI-поток
        searcher.StatusChanged += (_, e) => labelStatus.Text = e.Status;
        searcher.ProgressChanged += (_, e) => progressBar.Value = e.ProgressPercentage;
        searcher.SearchCompleted += OnEapSearchCompleted;

        searcher.SearchAsync(directory, word, _cts!.Token);
    }

    private void OnEapSearchCompleted(object? sender, SearchCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show($"Ошибка поиска:\n{e.Error.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            labelStatus.Text = "Ошибка.";
        }
        else if (e.Cancelled)
        {
            labelStatus.Text = "Поиск отменён.";
        }
        else
        {
            ShowResults(e.Results!);
        }

        FinishSearch();
    }

    #endregion

    #region Общие методы

    private void ShowResults(List<SearchResult> results)
    {
        foreach (var result in results)
        {
            var item = new ListViewItem(result.FileName);
            item.SubItems.Add(result.FilePath);
            item.SubItems.Add(result.Count.ToString());
            listViewResults.Items.Add(item);
        }

        labelStatus.Text = $"Готово. Найдено файлов: {results.Count}, " +
                           $"вхождений: {results.Sum(r => r.Count)}";
    }

    private void FinishSearch()
    {
        _cts?.Dispose();
        _cts = null;
        SetSearching(false);
    }

    private void buttonCancel_Click(object? sender, EventArgs e)
    {
        _cts?.Cancel();
    }

    private void SetSearching(bool searching)
    {
        buttonSearch.Enabled = !searching;
        buttonCancel.Enabled = searching;
        textBoxDirectory.Enabled = !searching;
        textBoxWord.Enabled = !searching;
        buttonBrowse.Enabled = !searching;
        radioApm.Enabled = !searching;
        radioEap.Enabled = !searching;
    }

    #endregion
}
