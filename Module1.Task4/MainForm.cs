using System.Runtime.InteropServices;

namespace Module1.Task4;

public partial class MainForm : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr FindWindow(string? lpClassName, string? lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, WindowMessage msg, IntPtr wParam, string lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hWnd, string text, string caption, MessageBoxType type);

    private readonly System.Windows.Forms.Timer _timer;
    private IntPtr _notepadHandle;

    public MainForm()
    {
        InitializeComponent();

        _timer = new System.Windows.Forms.Timer();
        _timer.Interval = 1000;
        _timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_notepadHandle == IntPtr.Zero || FindWindow("Notepad", null) == IntPtr.Zero)
        {
            StopUpdating();
            MessageBox(Handle, "Блокнот был закрыт.",
                "Информация", MessageBoxType.Ok | MessageBoxType.IconInformation);
            return;
        }

        string time = DateTime.Now.ToString("HH:mm:ss");
        SendMessage(_notepadHandle, WindowMessage.SetText, IntPtr.Zero, time);
        labelStatus.Text = $"Время: {time}";
    }

    private void buttonStart_Click(object? sender, EventArgs e)
    {
        _notepadHandle = FindWindow("Notepad", null);

        if (_notepadHandle == IntPtr.Zero)
        {
            MessageBox(Handle, "Блокнот не найден!\nОткройте Блокнот и попробуйте снова.",
                "Ошибка", MessageBoxType.Ok | MessageBoxType.IconWarning);
            return;
        }

        _timer.Start();
        buttonStart.Enabled = false;
        buttonStop.Enabled = true;
        labelStatus.Text = "Статус: Обновление запущено";
    }

    private void buttonStop_Click(object? sender, EventArgs e)
    {
        StopUpdating();
    }

    private void StopUpdating()
    {
        _timer.Stop();
        _notepadHandle = IntPtr.Zero;
        buttonStart.Enabled = true;
        buttonStop.Enabled = false;
        labelStatus.Text = "Статус: Остановлено";
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _timer.Stop();
        _timer.Dispose();
        base.OnFormClosing(e);
    }
}
