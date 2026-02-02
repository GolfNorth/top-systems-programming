using System.Runtime.InteropServices;

namespace Module1.Task1;

public partial class MainForm : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hWnd, string text, string caption, MessageBoxType type);

    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonShowMessage_Click(object? sender, EventArgs e)
    {
        // Вызов MessageBox из Windows API
        MessageBox(Handle, "Hello, World!", "Caption", MessageBoxType.Ok | MessageBoxType.IconInformation);
    }
}