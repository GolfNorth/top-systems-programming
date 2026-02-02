using System.Runtime.InteropServices;

namespace Module1.Task3;

public partial class MainForm : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr FindWindow(string? lpClassName, string? lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, WindowMessage msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hWnd, string text, string caption, MessageBoxType type);

    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonFind_Click(object? sender, EventArgs e)
    {
        IntPtr hWnd = FindWindow("Notepad", null);

        if (hWnd == IntPtr.Zero)
        {
            MessageBox(Handle, "Блокнот не найден!\nОткройте Блокнот и попробуйте снова.",
                "Результат поиска", MessageBoxType.Ok | MessageBoxType.IconWarning);
            labelStatus.Text = "Статус: Блокнот не найден";
        }
        else
        {
            labelStatus.Text = $"Статус: Найден (Handle: 0x{hWnd:X})";
            MessageBox(Handle, $"Блокнот найден!\nHandle окна: 0x{hWnd:X}",
                "Результат поиска", MessageBoxType.Ok | MessageBoxType.IconInformation);
        }
    }

    private void buttonClose_Click(object? sender, EventArgs e)
    {
        IntPtr hWnd = FindWindow("Notepad", null);

        if (hWnd == IntPtr.Zero)
        {
            MessageBox(Handle, "Блокнот не найден!\nОткройте Блокнот и попробуйте снова.",
                "Ошибка", MessageBoxType.Ok | MessageBoxType.IconWarning);
            labelStatus.Text = "Статус: Блокнот не найден";
        }
        else
        {
            SendMessage(hWnd, WindowMessage.Close, IntPtr.Zero, IntPtr.Zero);
            labelStatus.Text = "Статус: Отправлено WM_CLOSE";
            MessageBox(Handle, "Сообщение WM_CLOSE отправлено Блокноту.",
                "Готово", MessageBoxType.Ok | MessageBoxType.IconInformation);
        }
    }
}
