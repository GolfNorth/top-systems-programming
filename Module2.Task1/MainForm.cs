using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace Module2.Task1;

public partial class MainForm : Form
{
    private readonly Timer _timer;

    public MainForm()
    {
        InitializeComponent();

        _timer = new Timer();
        _timer.Tick += Timer_Tick;

        RefreshProcessList();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        RefreshProcessList();
    }

    private void RefreshProcessList()
    {
        listViewProcesses.BeginUpdate();
        listViewProcesses.Items.Clear();

        try
        {
            var processes = Process.GetProcesses()
                .OrderBy(p => p.ProcessName)
                .ToArray();

            foreach (var process in processes)
            {
                try
                {
                    var item = new ListViewItem(process.Id.ToString());
                    item.SubItems.Add(process.ProcessName);
                    item.SubItems.Add(FormatMemory(process.WorkingSet64));
                    item.SubItems.Add(GetProcessStartTime(process));
                    listViewProcesses.Items.Add(item);
                }
                catch
                {
                    // Пропускаем процессы без доступа
                }
            }

            labelCount.Text = $"Процессов: {listViewProcesses.Items.Count}";
            labelLastUpdate.Text = $"Обновлено: {DateTime.Now:HH:mm:ss}";
        }
        finally
        {
            listViewProcesses.EndUpdate();
        }
    }

    private static string FormatMemory(long bytes)
    {
        return $"{bytes / 1024.0 / 1024.0:F1} МБ";
    }

    private static string GetProcessStartTime(Process process)
    {
        try
        {
            return process.StartTime.ToString("HH:mm:ss");
        }
        catch
        {
            return "—";
        }
    }

    private void buttonRefresh_Click(object? sender, EventArgs e)
    {
        RefreshProcessList();
    }

    private void buttonStartAuto_Click(object? sender, EventArgs e)
    {
        _timer.Interval = (int)numericInterval.Value * 1000;
        _timer.Start();
        buttonStartAuto.Enabled = false;
        buttonStopAuto.Enabled = true;
        labelStatus.Text = $"Автообновление: каждые {numericInterval.Value} сек";
    }

    private void buttonStopAuto_Click(object? sender, EventArgs e)
    {
        _timer.Stop();
        buttonStartAuto.Enabled = true;
        buttonStopAuto.Enabled = false;
        labelStatus.Text = "Автообновление: выключено";
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _timer.Stop();
        _timer.Dispose();
        base.OnFormClosing(e);
    }
}
