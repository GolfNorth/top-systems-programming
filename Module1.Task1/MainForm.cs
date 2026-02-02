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
        MessageBox(Handle, "Привет, мир!", Text, MessageBoxType.Ok | MessageBoxType.IconInformation);
    }
}