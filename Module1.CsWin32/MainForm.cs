using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace Module1.CsWin32;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonMessageBox_Click(object? sender, EventArgs e)
    {
        PInvoke.MessageBox(
            new Windows.Win32.Foundation.HWND(Handle),
            "Привет из CsWin32!",
            "CsWin32 Demo",
            MESSAGEBOX_STYLE.MB_OK | MESSAGEBOX_STYLE.MB_ICONINFORMATION);
    }

    private void buttonFindNotepad_Click(object? sender, EventArgs e)
    {
        var hWnd = PInvoke.FindWindow("Notepad", null);

        if (hWnd.IsNull)
        {
            PInvoke.MessageBox(
                new Windows.Win32.Foundation.HWND(Handle),
                "Блокнот не найден!",
                "Результат",
                MESSAGEBOX_STYLE.MB_OK | MESSAGEBOX_STYLE.MB_ICONWARNING);
            labelStatus.Text = "Статус: Блокнот не найден";
        }
        else
        {
            labelStatus.Text = $"Статус: Найден (0x{(nint)hWnd:X})";
            PInvoke.MessageBox(
                new Windows.Win32.Foundation.HWND(Handle),
                $"Блокнот найден!\nHandle: 0x{(nint)hWnd:X}",
                "Результат",
                MESSAGEBOX_STYLE.MB_OK | MESSAGEBOX_STYLE.MB_ICONINFORMATION);
        }
    }

    private void buttonSetTitle_Click(object? sender, EventArgs e)
    {
        var hWnd = PInvoke.FindWindow("Notepad", null);

        if (hWnd.IsNull)
        {
            PInvoke.MessageBox(
                new Windows.Win32.Foundation.HWND(Handle),
                "Блокнот не найден!",
                "Ошибка",
                MESSAGEBOX_STYLE.MB_OK | MESSAGEBOX_STYLE.MB_ICONWARNING);
            return;
        }

        // SetWindowText через CsWin32
        string newTitle = $"CsWin32 - {DateTime.Now:HH:mm:ss}";
        PInvoke.SetWindowText(hWnd, newTitle);
        labelStatus.Text = $"Заголовок: {newTitle}";
    }
}
