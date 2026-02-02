using System.Diagnostics;

namespace Module2.Task4;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonNotepad_Click(object? sender, EventArgs e)
    {
        LaunchApplication("notepad.exe", "Блокнот");
    }

    private void buttonCalc_Click(object? sender, EventArgs e)
    {
        LaunchApplication("calc.exe", "Калькулятор");
    }

    private void buttonPaint_Click(object? sender, EventArgs e)
    {
        LaunchApplication("mspaint.exe", "Paint");
    }

    private void buttonBrowse_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Выберите приложение",
            Filter = "Исполняемые файлы (*.exe)|*.exe|Все файлы (*.*)|*.*",
            FilterIndex = 1
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            textBoxCustomPath.Text = dialog.FileName;
        }
    }

    private void buttonLaunchCustom_Click(object? sender, EventArgs e)
    {
        string path = textBoxCustomPath.Text.Trim();

        if (string.IsNullOrEmpty(path))
        {
            MessageBox.Show("Укажите путь к приложению.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        LaunchApplication(path, Path.GetFileName(path));
    }

    private void LaunchApplication(string path, string name)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            };

            var process = Process.Start(startInfo);

            if (process != null)
            {
                AddToLog($"Запущен: {name} (PID: {process.Id})");
            }
            else
            {
                AddToLog($"Запущен: {name}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не удалось запустить {name}:\n{ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            AddToLog($"Ошибка запуска: {name}");
        }
    }

    private void AddToLog(string message)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss");
        listBoxLog.Items.Insert(0, $"[{timestamp}] {message}");
    }
}
