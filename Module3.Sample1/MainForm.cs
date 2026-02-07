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

    private async void buttonSearch_Click(object? sender, EventArgs e)
    {
        string directory = textBoxDirectory.Text.Trim();
        string word = textBoxWord.Text.Trim();

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
        _cts = new CancellationTokenSource();

        progressBar.Value = 0;

        var progress = new Progress<string>(status =>
        {
            labelStatus.Text = status;
        });

        var percentProgress = new Progress<int>(percent =>
        {
            progressBar.Value = percent;
        });

        try
        {
            var results = await FileSearcher.SearchAsync(directory, word, progress, percentProgress, _cts.Token);

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
        catch (OperationCanceledException)
        {
            labelStatus.Text = "Поиск отменён.";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка поиска:\n{ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            labelStatus.Text = "Ошибка.";
        }
        finally
        {
            _cts.Dispose();
            _cts = null;
            SetSearching(false);
        }
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
    }
}
