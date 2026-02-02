using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace Module2.Task2;

public partial class MainForm : Form
{
    private readonly Timer _timer;
    private Process[] _processes = [];

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
        int? selectedPid = null;
        if (listViewProcesses.SelectedItems.Count > 0)
        {
            selectedPid = int.Parse(listViewProcesses.SelectedItems[0].Text);
        }

        listViewProcesses.BeginUpdate();
        listViewProcesses.Items.Clear();

        try
        {
            _processes = Process.GetProcesses()
                .OrderBy(p => p.ProcessName)
                .ToArray();

            foreach (var process in _processes)
            {
                try
                {
                    var item = new ListViewItem(process.Id.ToString());
                    item.SubItems.Add(process.ProcessName);
                    item.SubItems.Add(FormatMemory(process.WorkingSet64));
                    item.SubItems.Add(process.Threads.Count.ToString());
                    item.Tag = process;
                    listViewProcesses.Items.Add(item);

                    if (selectedPid == process.Id)
                    {
                        item.Selected = true;
                    }
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

    private void listViewProcesses_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (listViewProcesses.SelectedItems.Count == 0)
        {
            ClearProcessDetails();
            return;
        }

        var process = listViewProcesses.SelectedItems[0].Tag as Process;
        if (process == null)
        {
            ClearProcessDetails();
            return;
        }

        ShowProcessDetails(process);
    }

    private void ShowProcessDetails(Process process)
    {
        try
        {
            labelPidValue.Text = process.Id.ToString();
            labelNameValue.Text = process.ProcessName;

            try
            {
                labelStartTimeValue.Text = process.StartTime.ToString("dd.MM.yyyy HH:mm:ss");
            }
            catch
            {
                labelStartTimeValue.Text = "Нет доступа";
            }

            try
            {
                labelCpuTimeValue.Text = process.TotalProcessorTime.ToString(@"hh\:mm\:ss\.fff");
            }
            catch
            {
                labelCpuTimeValue.Text = "Нет доступа";
            }

            labelThreadsValue.Text = process.Threads.Count.ToString();
            labelMemoryValue.Text = FormatMemory(process.WorkingSet64);

            // Количество копий процесса с таким именем
            int instanceCount = _processes.Count(p => p.ProcessName == process.ProcessName);
            labelInstancesValue.Text = instanceCount.ToString();

            try
            {
                labelPriorityValue.Text = process.PriorityClass.ToString();
            }
            catch
            {
                labelPriorityValue.Text = "Нет доступа";
            }
        }
        catch
        {
            ClearProcessDetails();
        }
    }

    private void ClearProcessDetails()
    {
        labelPidValue.Text = "—";
        labelNameValue.Text = "—";
        labelStartTimeValue.Text = "—";
        labelCpuTimeValue.Text = "—";
        labelThreadsValue.Text = "—";
        labelMemoryValue.Text = "—";
        labelInstancesValue.Text = "—";
        labelPriorityValue.Text = "—";
    }

    private static string FormatMemory(long bytes)
    {
        return $"{bytes / 1024.0 / 1024.0:F1} МБ";
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
        labelStatus.Text = $"Авто: {numericInterval.Value} сек";
    }

    private void buttonStopAuto_Click(object? sender, EventArgs e)
    {
        _timer.Stop();
        buttonStartAuto.Enabled = true;
        buttonStopAuto.Enabled = false;
        labelStatus.Text = "Авто: выкл";
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _timer.Stop();
        _timer.Dispose();
        base.OnFormClosing(e);
    }
}
